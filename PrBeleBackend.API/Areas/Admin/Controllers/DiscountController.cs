using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{

    [Route("api/admin/[controller]")]
    [ApiController]
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

        [HttpGet]
        public async Task<IActionResult> Index(
           string? field,
           string? query,
           int? status,
           string? sort,
           SortOrderOptions? order = SortOrderOptions.ASC,
           int page = 1,
           int limit = 10
           )
        {
            List<DiscountResponse> allDiscounts = await _discountGetterService.GetAllDiscount();

            allDiscounts = allDiscounts
                .Where(a => status == 0 || status == 1 ? a.Status == status : true)
                .ToList();

            int totalAccount = allDiscounts.Count;

            List<DiscountResponse> discounts = await _discountGetterService.GetFilteredDiscount(field, query);

            List<DiscountResponse> paginaDiscount = discounts
                .Where(a => status == 0 || status == 1 ? a.Status == status : true)
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
                        totalPages = totalAccount / limit,
                        totalRecords = totalAccount
                    }
                },
                message = "Data fetched successfully."

            });
        }
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
                    data = discountResponse,
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
