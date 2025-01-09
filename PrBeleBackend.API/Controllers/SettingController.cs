using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.ServiceContracts.SettingContracts;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingGetterService _settingGetterService;
        public SettingController(ISettingGetterService settingGetterService)
        {
            _settingGetterService = settingGetterService;
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
    }
}
