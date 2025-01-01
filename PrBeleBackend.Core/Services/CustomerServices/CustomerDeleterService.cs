using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CustomerServices
{
    public class CustomerDeleterService : ICustomerDeleterService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerDeleterService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> DeleteCustomer(int Id)
        {
            Customer? matchingCustomer= await _customerRepository.GetCustomerById(Id);

            if (matchingCustomer == null)
            {
                return false;
            }
            bool result = await _customerRepository.DeleteCustomerById(Id);
            return result;
        }
    }
}
