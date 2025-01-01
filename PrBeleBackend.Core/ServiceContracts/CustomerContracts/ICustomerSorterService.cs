using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CustomerContracts
{
    public interface ICustomerSorterService
    {
        public Task<List<CustomerResponse>> SortCustomers(List<CustomerResponse> customerResponse, string? sort, string? order);

    }
}
