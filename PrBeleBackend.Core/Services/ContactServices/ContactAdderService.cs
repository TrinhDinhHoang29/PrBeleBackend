using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.ContactServices
{
    public class ContactAdderService : IContactAdderContract
    {
        private readonly IContactRepository _contactRepository;
        public ContactAdderService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<ContactResponse> AddContact(ContactAddRequest contactAddRequest)
        {
            ValidationHelper.ModelValidation(contactAddRequest);
            Contact contact = contactAddRequest.ToContact();
            contact.Status = 1;
            
            Contact result = await _contactRepository.AddContact(contact);
            return result.ToContactResponse();

        }
    }
}
