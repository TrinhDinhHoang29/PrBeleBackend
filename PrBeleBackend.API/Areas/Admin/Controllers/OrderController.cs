using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using System.Net;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderGetterService _orderGetterService;
        private readonly IOrderSorterService _orderSorterService;
        private readonly IOrderDeleterService _orderDeleterService;
        private readonly IOrderUpdaterService _orderUpdaterService;
        public OrderController(IOrderGetterService orderGetterService,
            IOrderSorterService orderSorterService,
            IOrderDeleterService orderDeleterService,
            IOrderUpdaterService orderUpdaterService
            )
        {
            _orderGetterService = orderGetterService;
            _orderSorterService = orderSorterService;
            _orderDeleterService = orderDeleterService;
            _orderUpdaterService = orderUpdaterService;
        }
        //[PermissionAuthorize("O-R")]

        [HttpGet]
        public async Task<IActionResult> Index(
                       int? status,
            string? sort,
            string field = "",
            string query = "",
           SortOrderOptions? order = SortOrderOptions.ASC,
           int page = 1,
           int limit = 10
            )
        {

            List<OrderResponse> orders = await _orderGetterService.GetFilteredOrder(field, query);
            orders = orders.Where(a => status >= -1 || status <= 4 ? a.Status == status : true).ToList();

            List<OrderResponse> paginaOrder = orders
                .Skip(limit * (page - 1)).Take(limit).ToList();

            List<OrderResponse> sortedOrder = await _orderSorterService.SortOrders(paginaOrder, sort, order.ToString());

            return Ok(new
            {
                status = 200,
                data = new
                {
                    orders = sortedOrder.Select(orderResponses => new
                    {
                        id = orderResponses.Id,
                        name = orderResponses.FullName,
                        phoneNumber = orderResponses.PhoneNumber,
                        email = orderResponses.Email,
                        address = orderResponses.Address,
                        note = orderResponses.Note,
                        payMethod = orderResponses.PayMethod,
                        shipDate = orderResponses.ShipDate,
                        receiveDate = orderResponses.ReceiveDate,
                        status = orderResponses.Status,
                        totalMoney = orderResponses.TotalMoney,
                        createdAt = orderResponses.CreatedAt,
                    }),
                    pagination = new
                    {
                        currentPage = page,
                        totalPage = Math.Ceiling((decimal)orders.Count / limit),

                    }
                },
                message = "Data fetched successfully."

            });
        }
        //[PermissionAuthorize("O-R")]

        [HttpGet("{Id}")]
        public async Task<IActionResult> Detail(int Id)
        {
                OrderResponse? orderResponses = await _orderGetterService.GetOrderById(Id);
                if (orderResponses == null)
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
                    discountValue = v.DiscountValue,
                    finalPrice = v.FinalPrice,
                    originalPrice = v.OriginalPrice,
                    quantity = v.Quantity,
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
                        email = orderResponses.Email,
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
        //[PermissionAuthorize("O-U")]

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateStatusOrder(int Id, OrderUpdatePatchRequest StatusRequest)
        {
            try
            {
                OrderResponse orderResponse = await _orderUpdaterService.UpdateStatusOrder(Id, StatusRequest);
                return Ok(new
                {
                    status = 200,
                    message = "Order status updated successfully.",
                    data = new { id = orderResponse.Id, status = orderResponse.Status }
                });
            }
            catch (Exception ex) {
                return BadRequest(new {
                    status = 400,
                    message = ex.Message
                }
                );
            }

        }
        //[PermissionAuthorize("O-D")]

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await _orderDeleterService.DeleteOrder(Id);
            if (result == false)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Order not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Order discount success !"
            });
        }
    }
}
