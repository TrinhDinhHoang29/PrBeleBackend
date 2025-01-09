using Microsoft.AspNetCore.Identity;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.AuthDTOs;
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
    public class CustomerAdderService : ICustomerAdderService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerAdderService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerResponse> AddCustomer(CliRegisterRequest cliRegisterRequest)
        {
            ValidationHelper.ModelValidation(cliRegisterRequest);
            Customer customerRequest = cliRegisterRequest.ToCustomer();
            var passwordHasher = new PasswordHasher<string>();
            string hashedPassword = passwordHasher.HashPassword(null, cliRegisterRequest.Password);
            customerRequest.Password = hashedPassword;
            Customer result = await _customerRepository.AddCustomer(customerRequest);
            return result.ToCustomerResponse();
        }
    }
}
