using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CustomerContracts
{
    public interface ICustomerAdderService
    {
        public Task<CustomerResponse> AddCustomer(CliRegisterRequest cliRegisterRequest);
    }
}
