using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CustomerContracts
{
    public interface ICustomerUpdaterService
    {
        public Task<CustomerResponse> UpdateCustomerPatch(int Id, CustomerUpdatePatchRequest? customerUpdateRequest);
        public Task<CustomerResponse> CliUpdateCustomer(int Id, CliCustomerUpdateRequest? customerUpdateRequest);
        public Task<CustomerResponse> CliUpdatePasswordCustomer(int Id, CliCustomerChangePasswordRequest? customerUpdateRequest);

        public Task<CustomerResponse> CliUpdatePasswordFromForgotCustomer(int Id, CliForgotPasswordRequest? cliForgotPasswordRequest);

    }
}
