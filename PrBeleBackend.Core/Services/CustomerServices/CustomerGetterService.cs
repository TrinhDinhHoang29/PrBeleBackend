using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CustomerServices
{
    public class CustomerGetterService : ICustomerGetterService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerGetterService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerResponse>> GetAllCustomer()
        {
            List<Customer> customers = await _customerRepository.GetAllCustomer();
            return customers.Select(c => c.ToCustomerResponse()).ToList();
        }

        public Task<CustomerResponse?> GetCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerResponse>> GetFilteredCustomer(string searchBy, string? searchString)
        {
            List<Customer> customers = await _customerRepository.GetAllCustomer();

            if (searchBy == string.Empty || searchString == string.Empty)
            {
                return customers.Select(c => c.ToCustomerResponse()).ToList();
            }
            switch (searchBy)
            {
                case nameof(Customer.FullName):
                    return customers.Where(a => a.FullName.Contains(searchString))
                        .Select(a => a.ToCustomerResponse()).ToList();
                case nameof(Customer.Email):
                    return customers.Where(a => a.Email.Contains(searchString))
                        .Select(a => a.ToCustomerResponse()).ToList();
                case nameof(Customer.PhoneNumber):
                    return customers.Where(a => a.PhoneNumber.Contains(searchString))
                        .Select(a => a.ToCustomerResponse()).ToList();
                default:
                    return customers.Select(a => a.ToCustomerResponse()).ToList();
            }
        }
    }
}
