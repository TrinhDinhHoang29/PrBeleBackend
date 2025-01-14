using PrBeleBackend.Core.DTO.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ContactContracts
{
    public interface IContactAdderContract
    {
        public Task<ContactResponse> AddContact(ContactAddRequest contactAddRequest);
    }
}
