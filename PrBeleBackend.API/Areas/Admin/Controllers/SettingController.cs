using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.SettingDTOs;
using PrBeleBackend.Core.ServiceContracts;
using PrBeleBackend.Core.ServiceContracts.SettingContracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingGetterService _settingGetterService;
        private readonly ISettingUpdaterService _settingUpdaterService;
        private readonly ICloudinaryContract _cloudinaryContract;
        public SettingController(
            ISettingGetterService settingGetterService,
            ISettingUpdaterService settingUpdaterService,
            ICloudinaryContract cloudinaryContract
            )
        {
            _settingGetterService = settingGetterService;
            _settingUpdaterService = settingUpdaterService;
            _cloudinaryContract = cloudinaryContract;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Setting setting = await _settingGetterService.GetSetting();
            return Ok(new
            {
                status = 200,
                message = "Settings retrieved successfully.",
                data = new
                {
                    setting = setting
                }
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(SettingUpdateRequest settingUpdateRequest)
        {
            try
            {
                Setting setting = await _settingUpdaterService.UpdateSetting(settingUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    message = "Settings updated successfully.",
                    data = new
                    {
                        setting = setting
                    }
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
    }
}
