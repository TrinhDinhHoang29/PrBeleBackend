using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentProject.Models;
using PaymentProject.VNPay;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.ServiceContracts.CartContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System.Net;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICartGetterService _cartGetterService;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IVnPayService _vnPayService;

        private readonly BeleStoreContext _dbContext;
        public CheckoutController(ICartRepository cartRepository, IOrderRepository orderRepository, ICartGetterService cartGetterService,BeleStoreContext beleStoreContext, IVnPayService vnPayService)
        {
            _cartRepository = cartRepository;
            _cartGetterService = cartGetterService;
            _dbContext = beleStoreContext;
            _vnPayService = vnPayService;
            _orderRepository = orderRepository;

        }
        [Authorize(Roles = "Client")]

        [HttpPost("VNPAY")]
        public async Task<IActionResult> Checkout(OrderAddRequest orderAddRequest)
        {
            try
            {
                // Lấy CustomerId từ Claims
                if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int customerId))
                {
                    return BadRequest(new { status = 400, message = "Invalid user." });
                }

                // Lấy giỏ hàng của người dùng
                Cart? cart = await _cartRepository.GetDetailCart(customerId);
                if (cart == null || !cart.ProductCarts.Any())
                {
                    return BadRequest(new { status = 400, message = "Cart is empty." });
                }

                // Kiểm tra tính khả dụng của các sản phẩm trong giỏ hàng
                var unavailableProductMessage = await ValidateCartItems(cart);
                if (!string.IsNullOrEmpty(unavailableProductMessage))
                {
                    return BadRequest(new { status = 400, message = unavailableProductMessage });
                }

                // Tạo thông tin thanh toán
                var paymentUrl = CreatePaymentUrl(cart, orderAddRequest, customerId);
                if (string.IsNullOrEmpty(paymentUrl))
                {
                    return BadRequest(new { status = 400, message = "Failed to create payment URL." });
                }

                return Ok(new
                {
                    status = 200,
                    data = paymentUrl,
                    message = "Redirect"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, message = ex.Message });
            }
        }

        [Authorize(Roles = "Client")]
        [HttpPost("COD")]
        public async Task<IActionResult> CheckoutCOD(OrderAddRequest orderAddRequest)
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                // Lấy và kiểm tra giỏ hàng
                Cart? cart = await _cartRepository.GetDetailCart(customerId);
                if (cart == null || !cart.ProductCarts.Any())
                {
                    return BadRequest(new { status = 400, message = "Cart is empty." });
                }

                // Kiểm tra tính khả dụng của các sản phẩm trong giỏ hàng
                var unavailableProductMessage = await ValidateCartItems(cart);
                if (!string.IsNullOrEmpty(unavailableProductMessage))
                {
                    return BadRequest(new { status = 400, message = unavailableProductMessage });
                }

                // Tạo đơn hàng mới
                var order = await _orderRepository.AddOrder(
                    new Order()
                    {
                        UserId = customerId,
                        FullName = orderAddRequest.FullName,
                        PhoneNumber = orderAddRequest.PhoneNumber,
                        Address = orderAddRequest.Address,
                        Note = orderAddRequest.Note,
                        Status = 1,
                        PayMethod = "COD"
                    });
                if (order == null)
                {
                    return BadRequest(new { status = 400, message = "Failed to create order." });
                }

                // Xử lý sản phẩm trong đơn hàng
                var result = await ProcessOrderItems(order, cart);
                if (!result)
                {
                    return BadRequest(new { status = 400, message = "Failed to process order items." });
                }

                // Xóa giỏ hàng cũ và tạo giỏ hàng mới
                await ResetCart(customerId);

                return Ok(new { status = 200, data = "", message = "Order placed successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, message = ex.Message });
            }
        }
       

        [HttpGet("PaymentCallbackVnpay")]
        public async Task<IActionResult> PaymentCallbackVnpay(int UserId, string FullName, string PhoneNumber, string Address, string Note)
        {
            try
            {
                // Xử lý phản hồi từ VNPAY
                PaymentResponseModel response = _vnPayService.PaymentExecute(Request.Query);
                if (!response.Success)
                {
                    return Ok(new
                    {
                        status = 400,
                        data = response,
                        message = "Payment failed."
                    });
                }

                // Lấy thông tin giỏ hàng
                Cart? cart = await _cartRepository.GetDetailCart(UserId);
                if (cart == null || !cart.ProductCarts.Any())
                {
                    return BadRequest(new { status = 400, message = "Cart is empty." });
                }

                // Tạo đơn hàng mới
                var order = await _orderRepository.AddOrder(new Order()
                                 {
                                     UserId = UserId,
                                     FullName = FullName,
                                     PhoneNumber = PhoneNumber,
                                     Address = Address,
                                     Note = Note,
                                     Status = 1,
                                     PayMethod = "VNPAY"
                                 });
                if (order == null)
                {
                    return BadRequest(new { status = 400, message = "Failed to create order." });
                }

                // Cập nhật kho hàng và xử lý sản phẩm trong đơn hàng
                var result = await ProcessOrderItems(order, cart);
                if (!result)
                {
                    return BadRequest(new { status = 400, message = "Failed to process order items." });
                }

                // Xóa giỏ hàng cũ và tạo giỏ hàng mới
                await ResetCart(UserId);

                return Redirect($"http://localhost:3000/cart?status=00");
            }
            catch (Exception ex)
            {
                return Redirect($"http://localhost:3000/cart?status=11&message={ex.Message}");

            }
        }

        [Authorize(Roles = "Client")]
        [HttpDelete("Cancel/{Id}")]
        public async Task<IActionResult> CancelOrder(int Id)
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                Order? orderExist = await _dbContext.orders
                .Include(o => o.ProductOrders)
                .ThenInclude(o => o.Variant)
                .Where(o => o.Status == 1 && o.UserId == customerId)
                .FirstOrDefaultAsync(o => o.Id == Id);
                if (orderExist == null)
                {
                    return BadRequest(new
                    {
                        status = 400,
                        message = "Request invalid."
                    });
                }
                foreach (var item in orderExist.ProductOrders)
                {
                    Variant? variant = await _dbContext.variants.FirstOrDefaultAsync(v => v.Id == item.VariantId);
                    variant.Stock = variant.Stock + item.Quantity;
                }
                orderExist.Status = -1;
                await _dbContext.SaveChangesAsync();
                return Ok(new
                {
                    status = 200,
                    message = "Cancel order success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }

        }





        // Phương thức kiểm tra tính khả dụng của các sản phẩm
        private async Task<string?> ValidateCartItems(Cart cart)
        {
            foreach (var productCart in cart.ProductCarts)
            {
                Variant? variant = await _dbContext.variants
                    .Where(v => v.Status == 1 && !v.Deleted)
                    .FirstOrDefaultAsync(v => v.Id == productCart.VariantId);

                if (variant == null || variant.Stock < productCart.Quantity)
                {
                    return $"Product {productCart.Variant?.Product?.Name} is unavailable.";
                }
            }
            return null;
        }

        // Phương thức tạo URL thanh toán
        private string CreatePaymentUrl(Cart cart, OrderAddRequest orderAddRequest, int customerId)
        {
            var model = new PaymentInformationModel
            {
                Name = orderAddRequest.FullName,
                Amount = (double)(cart.TotalMoney),
                OrderDescription = "Thanh toan qua vnpay",
                OrderType = "fashion"
            };

            return _vnPayService.CreatePaymentUrl(model, HttpContext, customerId,
                orderAddRequest.FullName,
                orderAddRequest.PhoneNumber,
                orderAddRequest.Address,
                orderAddRequest.Note);
        }

        // Tạo đơn hàng mới
        // Xử lý sản phẩm trong đơn hàng và cập nhật kho hàng
        private async Task<bool> ProcessOrderItems(Order order, Cart cart)
        {
            var productOrders = cart.ProductCarts.Select(item => new ProductOrder
            {
                OrderId = order.Id,
                Quantity = item.Quantity,
                VariantId = item.VariantId,
                OriginalPrice = item.Variant.Price,
                DiscountValue = item.Variant.Product.Discount?.ExpireDate > DateTime.Now ? item.Variant.Product.Discount.DiscountValue : 0,
                FinalPrice = item.Variant.Price *
                    (item.Variant.Product.Discount != null && item.Variant.Product.Discount.ExpireDate > DateTime.Now
                        ? 1.0m - item.Variant.Product.Discount.DiscountValue / 100.0m
                        : 1) * item.Quantity,
                IsRating = false
            }).ToList();
            order.TotalMoney = productOrders.Select(p => p.FinalPrice).Sum();
            foreach (var productOrder in productOrders)
            {
                var variant = await _dbContext.variants
                    .Where(v => v.Status == 1 && !v.Deleted)
                    .FirstOrDefaultAsync(v => v.Id == productOrder.VariantId);

                if (variant == null || variant.Stock < productOrder.Quantity)
                {
                    return false; // Không đủ hàng hoặc sản phẩm không khả dụng
                }

                variant.Stock -= productOrder.Quantity;
            }

            await _dbContext.productOrders.AddRangeAsync(productOrders);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        // Xóa giỏ hàng cũ và tạo giỏ hàng mới
        private async Task ResetCart(int userId)
        {
            var oldCart = await _dbContext.carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (oldCart != null)
            {
                _dbContext.carts.Remove(oldCart);
            }

            var newCart = new Cart
            {
                TotalMoney = 0,
                UserId = userId
            };

            await _dbContext.carts.AddAsync(newCart);
            await _dbContext.SaveChangesAsync();
        }




    

    }
}
