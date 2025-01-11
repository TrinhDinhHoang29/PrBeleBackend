using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrBeleBackend.Core.Domain.Entities;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class GoogleController : Controller
    {
        private readonly IConfiguration _configuration;

        public GoogleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("verify-recaptcha")]
        public async Task<IActionResult> Index(string recaptchaResponse)
        {
            var client = new HttpClient();

            var values = new Dictionary<string, string>
                {
                    { "secret", this._configuration["ReCaptcha:SecertKey"] },
                    { "response", recaptchaResponse }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);

            var responseString = await response.Content.ReadAsStringAsync();

            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            if (jsonData.success == "true")
            {
                return Ok(new
                {
                    status = 200,
                    message = "Verify reCaptcha success!"
                });
            }
            else
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Verify reCaptcha fail!"
                });
            }
        }
    }
}
