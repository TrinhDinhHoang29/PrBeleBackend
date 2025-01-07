using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.ServiceContracts.SettingContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingGetterService _settingGetterService;
        private readonly ISettingUpdaterService _settingUpdaterService;
        public SettingController(ISettingGetterService settingGetterService, ISettingUpdaterService settingUpdaterService)
        {
            _settingGetterService = settingGetterService;
            _settingUpdaterService = settingUpdaterService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Setting setting = await _settingGetterService.GetSetting();
            return Ok(new
            {
                status = 200,
                data = new
                {
                    setting = setting
                }
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            Setting setting = await _settingGetterService.GetSetting();
            return Ok(new
            {
                status = 200,
                data = new
                {
                    setting = setting
                }
            });
        }
    }
}
