using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ContactContracts
{
    public interface IContactUpdaterService
    {
        public Task<ContactResponse> UpdateContact(int Id, ContactUpdateRequest? contactUpdateRequest);
        public Task<ContactResponse> UpdateContactPatch(int Id, ContactUpdatePatchRequest? contactUpdateRequest);
    }
}
