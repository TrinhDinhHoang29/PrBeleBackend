using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.RateDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    //[Authorize]
    public class RateController : ControllerBase
    {
        private readonly IRateGetterService _rateGetterService;
        private readonly IRateAdderService _rateAdderService;
        private readonly IRateDeleterService _rateDeleterService;
        private readonly IRateUpdaterService _rateUpdaterService;
        private readonly IRateSortService _rateSortService;
        public RateController(
            IRateGetterService rateGetterService,
            IRateAdderService rateAdderService,
            IRateDeleterService rateDeleterService,
            IRateUpdaterService rateUpdaterService,
            IRateSortService rateSortService)
        {
            _rateGetterService = rateGetterService;
            _rateAdderService = rateAdderService;
            _rateDeleterService = rateDeleterService;
            _rateUpdaterService = rateUpdaterService;
            _rateSortService = rateSortService;
        }
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

            

            List<RateResponse> rates = await _rateGetterService.GetFilteredRate(field, query);
            rates= rates.Where(a => status == 0 || status == 1 ? a.Status == status : true).ToList();

            List<RateResponse> paginaRate = rates
                .Skip(limit * (page - 1)).Take(limit).ToList();

            List<RateResponse> sortedRate = await _rateSortService.SortRate(paginaRate, sort, order.ToString());

            return Ok(new
            {
                status = 200,
                data = new
                {
                    Rates = rates,
                    pagination = new
                    {
                        currentPage = page,
                        totalPage = Math.Ceiling((decimal)rates.Count / limit),
                    }
                },
                message = "Data fetched successfully."

            });

        }
        [HttpPost]
        public async Task<IActionResult> Reply(ReplyRateRequest replyRateRequest)
        {
            try
            {
                var subClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                   ?? User.FindFirst("sub")?.Value;
                string result = await _rateAdderService.ReplyRate(int.Parse(subClaim), replyRateRequest);
                return Ok(new
                {
                    status = 200,
                    message = result,
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
        [HttpPatch("{Id}")]
        public async Task<IActionResult> Edit(int Id,RateStatusUpdateRequest rateStatusUpdateRequest)
        {
            try
            {
                string result = await _rateUpdaterService.UpdateRateStatus(Id, rateStatusUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    message = result,
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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await _rateDeleterService.DeleteRate(Id);
            if (result == false)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Rate not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Delete rate success !"
            });
        }
    }
}
