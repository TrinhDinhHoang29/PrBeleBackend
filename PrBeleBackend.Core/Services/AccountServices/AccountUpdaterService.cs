using Microsoft.AspNetCore.Identity;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AccountServices
{
    public class AccountUpdaterService : IAccountUpdaterService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountUpdaterService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountResponse> UpdateAccount(int Id, AccountUpdateRequest? accountUpdateRequest)
        {
            Account? accountExist = await _accountRepository.GetAccountById(Id);

            if (accountExist == null) {
                throw new ArgumentNullException("Account not found !");
            }
            Account accountRequest = accountUpdateRequest.ToAccount();

            ValidationHelper.ModelValidation(accountUpdateRequest);

            var passwordHasher = new PasswordHasher<string>();
            string hashedPassword = passwordHasher.HashPassword(null, accountUpdateRequest.Password);
            accountRequest.Password = hashedPassword;

            Account? emailExist = await _accountRepository.GetAccountByEmail(accountUpdateRequest.Email);

            if (emailExist != null && emailExist.Id != Id) {
                throw new ArgumentNullException("Email already exists !");
            }

            accountRequest.Id = Id;
            accountRequest.UpdatedAt = DateTime.Now;
            Account result = await _accountRepository.UpdateAccount(accountRequest);

            return result.ToAccountResponse();

        }

        public async Task<AccountResponse> UpdateAccountPatch(int Id, AccountUpdatePatchRequest? accountUpdateRequest)
        {
            Account? accountExist = await _accountRepository.GetAccountById(Id);

            if (accountExist == null)
            {
                throw new ArgumentNullException("Account not found !");
            }
            accountExist.Status = accountUpdateRequest.Status;
            accountExist.UpdatedAt = DateTime.Now;
            ValidationHelper.ModelValidation(accountExist);

            Account result = await _accountRepository.UpdateAccount(accountExist);
            return result.ToAccountResponse();
        }
    }
}
