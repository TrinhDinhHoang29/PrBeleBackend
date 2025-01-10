using Microsoft.AspNetCore.Identity;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;


namespace PrBeleBackend.Core.Services.CustomerServices
{
    public class CustomerUpdaterService : ICustomerUpdaterService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerUpdaterService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResponse> CliUpdateCustomer(int Id, CliCustomerUpdateRequest? customerUpdateRequest)
        {
            Customer? customerExist = await _customerRepository.GetCustomerById(Id);
            if (customerExist == null)
            {
                throw new ArgumentNullException("Customer not found !");
            }
            ValidationHelper.ModelValidation(customerUpdateRequest);
            customerExist.UpdatedAt = DateTime.Now;
            customerExist.FullName = customerUpdateRequest.name;
            customerExist.PhoneNumber = customerUpdateRequest.phone;
            customerExist.Birthday = customerUpdateRequest.birthDay;
            customerExist.Sex = customerUpdateRequest.sex.ToString();

            Customer result = await _customerRepository.UpdateCustomer(customerExist);
            return result.ToCustomerResponse();
        }

        public async Task<CustomerResponse> CliUpdatePasswordCustomer(int Id, CliCustomerChangePasswordRequest? customerUpdateRequest)
        {
            Customer? customerExist = await _customerRepository.GetCustomerById(Id);
            if (customerExist == null)
            {
                throw new ArgumentNullException("Customer not found !");
            }
            ValidationHelper.ModelValidation(customerUpdateRequest);
            var passwordHasher = new PasswordHasher<string>();

            
            var checkPassword = passwordHasher.VerifyHashedPassword(null, customerExist.Password, customerUpdateRequest.currentPassword);

            if (checkPassword == PasswordVerificationResult.Failed)
            {
                throw new ArgumentException(message: "Invalid Password !!");
            }
            string hashedPassword = passwordHasher.HashPassword(null, customerUpdateRequest.newPassword);

            customerExist.UpdatedAt = DateTime.Now;
            customerExist.Password = hashedPassword;

            Customer result = await _customerRepository.UpdateCustomer(customerExist);
            return result.ToCustomerResponse();
        }
        public async Task<CustomerResponse> CliUpdatePasswordFromForgotCustomer(int Id, CliForgotPasswordRequest? cliForgotPasswordRequest)
        {
            Customer? customerExist = await _customerRepository.GetCustomerById(Id);
            if (customerExist == null)
            {
                throw new ArgumentNullException("Customer not found !");
            }
            ValidationHelper.ModelValidation(cliForgotPasswordRequest);
            var passwordHasher = new PasswordHasher<string>();

            string hashedPassword = passwordHasher.HashPassword(null, cliForgotPasswordRequest.Password);

            customerExist.UpdatedAt = DateTime.Now;
            customerExist.Password = hashedPassword;

            Customer result = await _customerRepository.UpdateCustomer(customerExist);
            return result.ToCustomerResponse();
        }

        public async Task<CustomerResponse> UpdateCustomerPatch(int Id, CustomerUpdatePatchRequest? customerUpdateRequest)
        {
            Customer? customerExist = await _customerRepository.GetCustomerById(Id);

            if (customerExist == null)
            {
                throw new ArgumentNullException("Customer not found !");
            }
            ValidationHelper.ModelValidation(customerUpdateRequest);

            customerExist.Status = customerUpdateRequest.Status;
            customerExist.UpdatedAt = DateTime.Now;

            Customer result = await _customerRepository.UpdateCustomer(customerExist);
            return result.ToCustomerResponse();
        }
    }
}
