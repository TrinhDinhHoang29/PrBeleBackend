using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactGetterSerivce _contactGetterSerivce;
        private readonly IContactSorterService _contactSorterService;
        private readonly IContactUpdaterService _contactUpdaterService;
        private readonly IContactDeleterService _contactDeleterService;
        public ContactController(
            IContactGetterSerivce contactGetterSerivce,
            IContactSorterService contactSorterService,
            IContactUpdaterService contactUpdaterService,
            IContactDeleterService contactDeleterService
            )
        {
            _contactGetterSerivce = contactGetterSerivce;
            _contactSorterService = contactSorterService;
            _contactUpdaterService = contactUpdaterService;
            _contactDeleterService = contactDeleterService;
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
            List<ContactResponse> allContact= await _contactGetterSerivce.GetAllContact();

            allContact = allContact
                .Where(a => status == 0 || status == 1 ? a.Status == status : true)
                .ToList();

            int totalCustomer = allContact.Count;

            List<ContactResponse> contacts = await _contactGetterSerivce.GetFilteredContact(field, query);

            List<ContactResponse> paginaContact= contacts
                .Where(a => status == 0 || status == 1 ? a.Status == status : true)
                .Skip(limit * (page - 1)).Take(limit).ToList();

            List<ContactResponse> sortedConact= await _contactSorterService.SortCustomers(paginaContact, sort, order.ToString());

            return Ok(new
            {
                status = 200,
                data = new
                {
                    contacts = sortedConact,
                    pagination = new
                    {
                        currentPage = page,
                        totalPages = totalCustomer / limit,
                        totalRecords = totalCustomer
                    }
                },
                message = "Data fetched successfully."

            });
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> Edit(int Id, ContactUpdatePatchRequest contactUpdateRequest)
        {
            try
            {
                ContactResponse contactResponse = await _contactUpdaterService
                    .UpdateContactPatch(Id, contactUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = contactResponse,
                    message = "Contact status updated successfully."
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
            bool result = await _contactDeleterService.DeleteContact(Id);
            if (result == false)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Contact not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Delete contact success !"
            });
        }
    }
}
