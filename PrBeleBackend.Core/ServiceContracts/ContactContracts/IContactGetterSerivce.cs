using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ContactContracts
{
    public interface IContactGetterSerivce
    {
        public Task<List<ContactResponse>> GetAllContact();

        public Task<ContactResponse?> GetContactById(int Id);

        public Task<List<ContactResponse>> GetFilteredContact(string searchBy, string? searchString);
    }
}
