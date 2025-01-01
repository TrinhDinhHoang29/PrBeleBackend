using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CustomerServices
{
    public class CustomerUpdaterService : ICustomerUpdaterService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerUpdaterService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerResponse> UpdateCustomerPatch(int Id, CustomerUpdatePatchRequest? customerUpdateRequest)
        {
            Customer? customerExist = await _customerRepository.GetCustomerById(Id);

            if (customerExist == null)
            {
                throw new ArgumentNullException("Customer not found !");
            }
            customerExist.Status = customerUpdateRequest.Status;
            customerExist.UpdatedAt = DateTime.Now;
            ValidationHelper.ModelValidation(customerExist);

            Customer result = await _customerRepository.UpdateCustomer(customerExist);
            return result.ToCustomerResponse();
        }
    }
}
