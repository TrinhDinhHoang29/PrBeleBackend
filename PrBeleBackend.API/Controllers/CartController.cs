using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CartDTOs;
using PrBeleBackend.Core.ServiceContracts.CartContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class CartController : ControllerBase
    {
        private readonly BeleStoreContext _dbContext;
        private readonly ICartGetterService _cartGetterService;
        public CartController(BeleStoreContext dbContext,ICartGetterService cartGetterService)
        {
            _dbContext = dbContext;
            _cartGetterService = cartGetterService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            CartResponse? cartResponse = await _cartGetterService.GetDetail(customerId);
            return Ok(new
            {
                status = 200,
                Data = new
                {
                    Cart = cartResponse
                },
                message = "Fetch success ."
            });
        }
        [HttpPut]
        public async Task<IActionResult> Put(CartUpdateRequest cartUpdateRequest)
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                Cart? cartExist = await _dbContext.carts
                   .Include(c => c.ProductCarts)
                   .ThenInclude(c => c.Variant)
                   .FirstOrDefaultAsync(a => a.UserId == customerId);
                if (cartExist == null)
                {
                    return BadRequest(new
                    {
                        status = 400,
                        message = "fail"
                    });
                }
                Variant variant = await _dbContext.variants.FirstOrDefaultAsync(a => a.Id == cartUpdateRequest.VariantId);
                if (variant == null) {
                    return BadRequest(new
                    {
                        status = 400,
                        message = "fail"
                    });
                }

                var existingProductCart = cartExist.ProductCarts.FirstOrDefault(p => p.VariantId == cartUpdateRequest.VariantId);
                if (existingProductCart == null )
                {
                    if(cartUpdateRequest.Quantity <1)
                    {
                        return BadRequest(new
                        {
                            status = 400,
                            message = "Fail"
                        });
                    }
                    cartExist.ProductCarts.Add(new ProductCart
                    {
                        CartId = cartExist.Id,
                        VariantId = cartUpdateRequest.VariantId,
                        Quantity = cartUpdateRequest.Quantity,
                    });
                }
                else
                {
                    existingProductCart.Quantity += cartUpdateRequest.Quantity;

                    if (existingProductCart.Quantity <= 0)
                    {
                        cartExist.ProductCarts.Remove(existingProductCart);
                    }
                }
                await _dbContext.SaveChangesAsync();

                Cart? cartResult = await _dbContext.carts
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
                // Cập nhật TotalMoney
                cartResult.TotalMoney = cartResult.ProductCarts
                    .Sum(pc =>
                    {
                        return pc.Variant.Price *
                        (pc.Variant.Product.Discount != null && pc.Variant.Product.Discount.ExpireDate > DateTime.Now ?
                            1 - (decimal)pc.Variant.Product.Discount.DiscountValue / 100.0m : 1)
                            * pc.Quantity;
                    });

                await _dbContext.SaveChangesAsync();

                // Lưu thay đổi
                var CartItems = cartResult?.ProductCarts.Select(item => new
                {
                    ProductId = item.Variant?.ProductId,
                    ProductName = item.Variant?.Product?.Name,
                    ProductPrice = item.Variant?.Price,
                    Thumbnail = item.Variant.Thumbnail,
                    Attributes = item?.Variant?.VariantAttributeValues?.Select(e => new Dictionary<string, string?>
                {
                    { e.AttributeValue.AttributeType.Name, e.AttributeValue.Name }
                }),

                    Quantity = item?.Quantity,
                    Discount = item?.Variant?.Product?.Discount?.ExpireDate > DateTime.Now ? item.Variant.Product?.Discount.DiscountValue : 0,
                });
                return Ok(new
                {
                    status = 200,
                    Data = new
                    {
                        Cart = new
                        {
                            TotalMoney = cartResult?.TotalMoney,
                            CartItems = CartItems

                        }
                    },
                    message = "Fetch success ."
                });
            }
            catch (Exception ex) { 
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
           
        }
        [HttpDelete]

        public async Task<IActionResult> Delete()
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                Cart? cartExist = await _dbContext.carts
                       .FirstOrDefaultAsync(a => a.UserId == customerId);
                _dbContext.carts.Remove(cartExist);
                await _dbContext.SaveChangesAsync();
                Cart result = new Cart
                {
                    TotalMoney = 0,
                    UserId = customerId,
                };
                await _dbContext.carts.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return Ok(new
                {
                    status = 200,
                    Data = new
                    {
                        Cart = new
                        {
                            TotalMoney = 0,
                            CartItems = new object[] { }

                        }
                    },
                    message = "Fetch success ."
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    status = 400,
                    
                    message = ex.Message
                });
            }
        }
    }
}
