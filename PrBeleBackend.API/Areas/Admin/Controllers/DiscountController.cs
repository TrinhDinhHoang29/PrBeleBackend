using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{

    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountAdderService _discountAdderService;
        private readonly IDiscountDeleterService _discountDeleterService;
        private readonly IDiscountGetterService _discountGetterService;
        private readonly IDiscountSorterService _discountSorterService;
        private readonly IDiscountUpdaterService _discountUpdaterService;
        public DiscountController(
            IDiscountAdderService discountAdderService,
            IDiscountDeleterService discountDeleterService,
            IDiscountGetterService discountGetterService,
            IDiscountSorterService discountSorterService,
            IDiscountUpdaterService discountUpdaterService
            )
        {
            _discountAdderService = discountAdderService;
            _discountDeleterService = discountDeleterService;
            _discountGetterService = discountGetterService;
            _discountSorterService = discountSorterService;
            _discountUpdaterService = discountUpdaterService;
        }
        [PermissionAuthorize("DC-R")]
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
           
            List<DiscountResponse> discounts = await _discountGetterService.GetFilteredDiscount(field, query);
            discounts= discounts.Where(a => status == 0 || status == 1 ? a.Status == status : true).ToList();

            List<DiscountResponse> paginaDiscount = discounts
                .Skip(limit * (page - 1)).Take(limit).ToList();

            List<DiscountResponse> sortedDiscount = await _discountSorterService.SortDiscounts(paginaDiscount, sort, order.ToString());

            return Ok(new
            {
                status = 200,
                data = new
                {
                    discounts = sortedDiscount,
                    pagination = new
                    {
                        currentPage = page,
                        totalPage = Math.Ceiling((decimal)discounts.Count / limit),

                    }
                },
                message = "Data fetched successfully."

            });
        }
        [PermissionAuthorize("DC-R")]

        [HttpGet("{Id}")]
        public async Task<IActionResult> Detail(int Id)
        {
            DiscountResponse? discountResponse = await _discountGetterService.GetDiscountById(Id);
            if (discountResponse == null)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Discount not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                data = discountResponse,
                message = "Data fetched successfully."
            });
        }
        [PermissionAuthorize("DC-C")]

        [HttpPost]
        public async Task<IActionResult> Create(DiscountAddRequest discountAddRequest)
        {
            try
            {
                DiscountResponse discount = await _discountAdderService.AddDiscount(discountAddRequest);

                return Created("/api/admin/accounts/" + discount.Id, new
                {
                    status = 201,
                    data = discount,
                    message = "Account created successfully."
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
        [PermissionAuthorize("DC-U")]

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, DiscountUpdateRequest discountUpdateRequest)
        {
            try
            {
                DiscountResponse discountResponse = await _discountUpdaterService
                    .UpdateDiscount(Id, discountUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = discountResponse,
                    message = "Discount updated successfully."
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
        [PermissionAuthorize("DC-U")]

        [HttpPatch("{Id}")]
        public async Task<IActionResult> Edit(int Id, DiscountUpdatePatchRequest discountUpdateRequest)
        {
            try
            {
                DiscountResponse discountResponse = await _discountUpdaterService
                    .UpdateDiscountPatch(Id, discountUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        Id = discountResponse.Id,
                        Status = discountResponse.Status,
                        UpdatedAt = discountResponse.UpdatedAt
                    },
                    message = "Discount status updated successfully."
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
        [PermissionAuthorize("DC-D")]

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await _discountDeleterService.DeleteDiscount(Id);
            if (result == false)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Discount not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Delete discount success !"
            });
        }
    }
}
