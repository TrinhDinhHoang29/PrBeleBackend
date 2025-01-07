using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.RateDTOs;
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
        public RateController(
            IRateGetterService rateGetterService,
            IRateAdderService rateAdderService,
            IRateDeleterService rateDeleterService,
            IRateUpdaterService rateUpdaterService)
        {
            _rateGetterService = rateGetterService;
            _rateAdderService = rateAdderService;
            _rateDeleterService = rateDeleterService;
            _rateUpdaterService = rateUpdaterService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RateResponse> rateResponses = await _rateGetterService.GetAllRate();
            return Ok(rateResponses);

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
