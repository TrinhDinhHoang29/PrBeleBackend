using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
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
    public class ContactUpdaterService : IContactUpdaterService
    {
        private readonly IContactRepository _contactRepository;
        public ContactUpdaterService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public Task<ContactResponse> UpdateContact(int Id, ContactUpdateRequest? contactUpdateRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactResponse> UpdateContactPatch(int Id, ContactUpdatePatchRequest? contactUpdateRequest)
        {
            Contact? contactExist = await _contactRepository.GetContactById(Id);

            if (contactExist == null)
            {
                throw new ArgumentNullException("Contact not found !");
            }
            contactExist.Status = contactUpdateRequest.Status;

            ValidationHelper.ModelValidation(contactExist);

            Contact result = await _contactRepository.UpdateContact(contactExist);
            return result.ToContactResponse();
        }
    }
}
