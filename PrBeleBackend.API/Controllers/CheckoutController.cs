using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentProject.Models;
using PaymentProject.VNPay;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CartDTOs;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.ServiceContracts.CartContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICartGetterService _cartGetterService;
        private readonly IVnPayService _vnPayService;

        private readonly BeleStoreContext _dbContext;
        public CheckoutController(ICartGetterService cartGetterService,BeleStoreContext beleStoreContext, IVnPayService vnPayService)
        {
            _cartGetterService = cartGetterService;
            _dbContext = beleStoreContext;
            _vnPayService = vnPayService;

        }
        [Authorize(Roles = "Client")]

        [HttpPost("VNPAY")]
        public async Task<IActionResult> Checkout(OrderAddRequest orderAddRequest)
        {
            try
            {
                //Check stock
                //-> Khong du
                //-> Check Pay
                //-> Offline 
                //-> VNpay -> Success
                //-> validation
                //-> - stock

                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                Cart? cart = await _dbContext.carts
                    .Include(c => c.ProductCarts)
                        .ThenInclude(c => c.Variant)
                            .ThenInclude(c => c.Product)
                                .ThenInclude(c => c.Discount)
                    .Include(c => c.ProductCarts)
                        .ThenInclude(c => c.Variant)
                            .ThenInclude(c => c.VariantAttributeValues)
                                .ThenInclude(c => c.AttributeValue)
                                    .ThenInclude(c => c.AttributeType)
                    .FirstOrDefaultAsync(a => a.UserId == customerId);

                var CartItems = cart?.ProductCarts.Select(item => new
                {
                    ProductName = item.Variant?.Product?.Name,
                    attribute = item?.Variant?.VariantAttributeValues?.Select(e => new Dictionary<string, string?>
                    {
                        { e.AttributeValue.AttributeType.Name, e.AttributeValue.Name }
                    }),

                    Quantity = item?.Quantity,
                    Discout = item?.Variant?.Product?.Discount?.ExpireDate > DateTime.Now ? item.Variant.Product?.Discount.DiscountValue : 0,
                });
                if (!CartItems.Any())
                {
                    return BadRequest(new
                    {
                        status = 400,
                        message = "Cart is null."
                    });
                }
                foreach(var productCart in cart.ProductCarts)
                {
                    Variant? variant = await _dbContext.variants
                        .Where(c => c.Status == 1 && c.Deleted == false)
                        .FirstOrDefaultAsync(c => c.Id == productCart.VariantId);
                    if (variant == null) {
                        return BadRequest("This product is currently unavailable.");
                    }
                    if(variant.Stock < productCart.Quantity)
                    {
                        return BadRequest("This product is currently unavailable.");
                    }
                }
     
 

                PaymentInformationModel model = new PaymentInformationModel();
                model.Name = orderAddRequest.FullName;
                model.Amount = Double.Parse(cart.TotalMoney.ToString());
                model.OrderDescription = "Thanh toan qua vnpay";
                model.OrderType = "fashion";

                var url = _vnPayService.CreatePaymentUrl(model, HttpContext, customerId,
                    orderAddRequest.FullName,
                    orderAddRequest.PhoneNumber,
                    orderAddRequest.Address,
                    orderAddRequest.Note
                    );
                return Ok(new
                {
                    status = 200,
                    data = url,
                    message = "Redirect"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }
        [HttpGet("PaymentCallbackVnpay")]
        public async Task<IActionResult> PaymentCallbackVnpay(int UserId, string FullName
            , string PhoneNumber,
            string Address,
            string Note)
        {
            try
            {

                var response = _vnPayService.PaymentExecute(Request.Query);

                //string result = _memoryCache.Get("ID").ToString();
                //
                return Ok(new
                {
                    status =200,
                    data = response,
                    UserId= UserId,
                   
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
            
        }
    }
}
