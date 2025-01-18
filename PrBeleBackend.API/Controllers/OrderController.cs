using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderGetterService _orderGetterService;
        private readonly IOrderUpdaterService _orderUpdaterService;

        public OrderController(
            IOrderGetterService orderGetterService,
            IOrderUpdaterService orderUpdaterService
            )
        {
            _orderGetterService = orderGetterService;
            _orderUpdaterService = orderUpdaterService;
        }
        [HttpGet]   
        public async Task<IActionResult> Get(int? status)
        {
            
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<OrderResponse> orderResponses = await _orderGetterService.GetAllOrder();
            if(status != null)
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        orders = orderResponses.Where(o => o.UserId == int.Parse(customerId) && o.Status == status
                                ).Select(orderResponses => new
                                {
                                    id = orderResponses.Id,
                                    name = orderResponses.FullName,
                                    phoneNumber = orderResponses.PhoneNumber,
                                    address = orderResponses.Address,
                                    note = orderResponses.Note,
                                    payMethod = orderResponses.PayMethod,
                                    shipDate = orderResponses.ShipDate,
                                    receiveDate = orderResponses.ReceiveDate,
                                    status = orderResponses.Status,
                                    totalMoney = orderResponses.TotalMoney,
                                    createdAt = orderResponses.CreatedAt,
                                }).ToList(),
                     },
                    message = "Data fetched successfully."
                });
            return Ok(new
            {
                status = 200,
                data = new
                {
                    orders = orderResponses.Where(o => o.UserId == int.Parse(customerId)
                               ).Select(orderResponses => new
                               {
                                   id = orderResponses.Id,
                                   name = orderResponses.FullName,
                                   phoneNumber = orderResponses.PhoneNumber,
                                   address = orderResponses.Address,
                                   note = orderResponses.Note,
                                   payMethod = orderResponses.PayMethod,
                                   shipDate = orderResponses.ShipDate,
                                   receiveDate = orderResponses.ReceiveDate,
                                   status = orderResponses.Status,
                                   totalMoney = orderResponses.TotalMoney,
                                   createdAt = orderResponses.CreatedAt,
                               }).ToList(),
                },
                message = "Data fetched successfully."
            });
        }

        [HttpGet("detail/{Id}")]
        public async Task<IActionResult> Detail(int Id)
        {
            OrderResponse? orderResponses = await _orderGetterService.GetOrderById(Id);
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (orderResponses == null || orderResponses.UserId != int.Parse(customerId))
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Order not found !"
                });
            }
            var variants = orderResponses?.ProductOrders?.Select(v => new
            {
                id = v.Variant.Id,
                name = v.Variant.Product?.Name,
                thumbnail = v.Variant.Thumbnail,
                productId = v.Variant.ProductId,
                price = v.Variant.Price,
                quantity = v.Quantity,
                slug = v.Variant.Product.Slug,
                discount = v.Variant.Product.Discount.DiscountValue,
                attribute = v.Variant.VariantAttributeValues?.Select(e => new Dictionary<string, string>
                {
                    { e.AttributeValue.AttributeType.Name, e.AttributeValue.Name }
                })
            });
            return Ok(new
            {
                status = 200,
                data = new
                {
                    id = orderResponses.Id,
                    name = orderResponses.FullName,
                    phoneNumber = orderResponses.PhoneNumber,
                    address = orderResponses.Address,
                    note = orderResponses.Note,
                    payMethod = orderResponses.PayMethod,
                    shipDate = orderResponses.ShipDate,
                    receiveDate = orderResponses.ReceiveDate,
                    status = orderResponses.Status,
                    totalMoney = orderResponses.TotalMoney,
                    createdAt = orderResponses.CreatedAt,
                    variants = variants,
                },
                message = "Data fetched successfully."
            });


        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> CancelOrder(int Id)
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                OrderResponse orderResponse = await _orderUpdaterService.CancelOrder(Id,int.Parse(customerId));
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        Id = orderResponse.Id,
                        status = orderResponse.Status,
                    },
                    message = "Order cancelled successfully."
                });
            } catch (Exception ex) {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
             
        }
    }
}
