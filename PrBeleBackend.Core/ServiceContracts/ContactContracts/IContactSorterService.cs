using PrBeleBackend.Core.DTO.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ContactContracts
{
    public interface IContactSorterService
    {
        public Task<List<ContactResponse>> SortCustomers(List<ContactResponse> contactResponse, string? sort, string? order);

    }
}
