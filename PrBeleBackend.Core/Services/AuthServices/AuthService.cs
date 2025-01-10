using Microsoft.AspNetCore.Identity;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.AuthContracts;
using PrBeleBackend.Core.ServiceContracts.JwtContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IJwtService _jwtService;
        private readonly IRoleRepository _roleRepository;
        private readonly ICustomerRepository _customerRepository;
        public AuthService(
            IAccountRepository accountRepository,
            IJwtService jwtService,
            IRoleRepository roleRepository,
            ICustomerRepository customerRepository
            )
        {
            _accountRepository = accountRepository;
            _jwtService = jwtService;
            _roleRepository = roleRepository;
            _customerRepository = customerRepository;
        }
        public async Task<JwtResponse> Login(LoginRequest loginRequest)
        {
            ValidationHelper.ModelValidation(loginRequest);
            Account? existAccount = await _accountRepository.GetAccountByEmail(loginRequest.Email);
            if (existAccount == null) { 
                throw new Exception(message:"Can't find Account !!");
            };
            var passwordHasher = new PasswordHasher<string>();
            
            if(existAccount.Status == 0)
            {
                throw new Exception(message: "Account don't active !!");

            }

            var result = passwordHasher.VerifyHashedPassword(null, existAccount.Password, loginRequest.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception(message: "Invalid Password !!");
            }

            var role = await _roleRepository.GetRoleById(existAccount.RoleId);
            List<string> permissions = role.RolePermissions.Select(p => p.Permission.Code).ToList();
            JwtResponse jwtResponse = await _jwtService.GenarateJwt(existAccount.ToAccountResponse(), permissions);
            existAccount.RefreshToken = jwtResponse.RefreshToken;
            existAccount.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;
            await _accountRepository.UpdateAccount(existAccount);

            return jwtResponse;
        }

        public async Task<JwtResponse> CliLogin(LoginRequest loginRequest)
        {
            ValidationHelper.ModelValidation(loginRequest);
            Customer? existCustomer = await _customerRepository.GetCustomerByEmail(loginRequest.Email);
            if (existCustomer == null)
            {
                throw new Exception(message: "Can't find Account !!");
            };
            var passwordHasher = new PasswordHasher<string>();

            if (existCustomer.Status == 0)
            {
                throw new Exception(message: "Account don't active !!");

            }
            var result = passwordHasher.VerifyHashedPassword(null, existCustomer.Password, loginRequest.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception(message: "Invalid Password !!");
            }
            JwtResponse jwtResponse = await _jwtService.GenarateJwtClient(existCustomer.ToCustomerResponse());
            existCustomer.RefreshToken = jwtResponse.RefreshToken;
            existCustomer.RefreshTokenExpirationDateTime = jwtResponse.RefreshTokenExpirationDateTime;
            await _customerRepository.UpdateCustomer(existCustomer);
            return jwtResponse;
        }
        public async Task<JwtResponse> RefreshToken(RefrestTokenRequest refrestTokenRequest)
        {
            Account? account = await _accountRepository.GetAccountByRefreshToken(refrestTokenRequest.RefreshToken);
            if (account == null) {
                throw new Exception(message: "Can't find token !!");
            }
            if(account.RefreshTokenExpirationDateTime <= DateTime.Now)
            {
                throw new Exception("Refresh token has expired. Please log in again.");
            }
            var role = await _roleRepository.GetRoleById(account.RoleId);
            List<string> permissions = role.RolePermissions.Select(p => p.Permission.Code).ToList();

            JwtResponse jwtResponse = await _jwtService.GenarateJwt(account.ToAccountResponse(), permissions);
            account.RefreshToken = jwtResponse.RefreshToken;
            await _accountRepository.UpdateAccount(account);
            return jwtResponse;
        }

        public async Task<bool> Logout(int Id)
        {
            Account? account = await _accountRepository.GetAccountById(Id);
            if (account == null)
            {
                return false;
            }
            account.RefreshToken = null;
            await _accountRepository.UpdateAccount(account);
            return true;

        }
        public async Task<bool> CliLogout(int Id)
        {
            Customer? customer = await _customerRepository.GetCustomerById(Id);
            if (customer == null) { 
                return false;
            }
            customer.RefreshToken = null;
            await _customerRepository.UpdateCustomer(customer);
            return true;

        }
    }
}
