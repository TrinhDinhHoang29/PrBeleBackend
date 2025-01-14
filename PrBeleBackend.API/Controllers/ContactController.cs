using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactAdderContract _contactAdderContract;
        public ContactController(IContactAdderContract contactAdderContract)
        {
            _contactAdderContract = contactAdderContract;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactAddRequest contactAddRequest)
        {
            try
            {
                ContactResponse contactResponse = await _contactAdderContract.AddContact(contactAddRequest);
                return Ok(new
                {
                    status = 200,
                    data = new {
                        contact = contactResponse   
                    },
                    message = "Create contact success."
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
    }
}
