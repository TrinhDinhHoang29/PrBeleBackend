using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CustomerContracts
{
    public interface ICustomerGetterService
    {
        public Task<List<CustomerResponse>> GetAllCustomer();

        public Task<CustomerResponse?> GetCustomerById(int Id);
        public Task<CustomerResponse?> GetCustomerByEmail(string Email);


        public Task<List<CustomerResponse>> GetFilteredCustomer(string searchBy, string? searchString);
    }
}
