using Microsoft.AspNetCore.Identity;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AccountServices
{
    public class AccountAdderService : IAccountAdderService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountAdderService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountResponse> AddAccount(AccountAddRequest accountAddRequest)
        {

           
            ValidationHelper.ModelValidation(accountAddRequest);

  

            Account? emailExists = await _accountRepository.GetAccountByEmail(accountAddRequest.Email);
            if (emailExists != null) {
                throw new Exception(message: "Email already exists.");
            }
            var passwordHasher = new PasswordHasher<string>();
            string hashedPassword = passwordHasher.HashPassword(null, accountAddRequest.Password);

            Account account = accountAddRequest.ToAccount();
            account.CreatedAt = DateTime.Now;
            account.UpdatedAt = DateTime.Now;

            account.Password = hashedPassword;
            Account result = await _accountRepository.AddAccount(account);

            return result.ToAccountResponse();            
        }
    }
}
