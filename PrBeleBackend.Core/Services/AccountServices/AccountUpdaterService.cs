﻿using Microsoft.AspNetCore.Identity;
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
        public async Task<AccountResponse> UpdateAccount(int Id, AccountUpdateRequest? accountUpdateRequest,AccountUpdatePasswordRequest accountUpdatePassword)
        {
            Account? accountExist = await _accountRepository.GetAccountById(Id);
            
            if (accountExist == null) {
                throw new ArgumentNullException("Account not found !");
            }
            if(accountUpdatePassword.Password != null || accountUpdatePassword.RePassword != null)
            {
                ValidationHelper.ModelValidation(accountUpdatePassword);
                var passwordHasher = new PasswordHasher<string>();
                string hashedPassword = passwordHasher.HashPassword(null, accountUpdatePassword.Password);
                accountExist.Password = hashedPassword;


            }
            ValidationHelper.ModelValidation(accountUpdateRequest);

            accountExist.FullName = accountUpdateRequest.FullName;
            accountExist.Status = accountUpdateRequest.Status;
            accountExist.PhoneNumber = accountUpdateRequest.PhoneNumber;
            accountExist.Email = accountUpdateRequest.Email;
            accountExist.RoleId = accountUpdateRequest.RoleId;

            accountExist.Sex = accountUpdateRequest.Sex.ToString();

            Account? emailExist = await _accountRepository.GetAccountByEmail(accountUpdateRequest.Email);

            if (emailExist != null && emailExist.Id != Id) {
                throw new ArgumentNullException("Email already exists !");
            }

            accountExist.UpdatedAt = DateTime.Now;
            Account result = await _accountRepository.UpdateAccount(accountExist);

            return result.ToAccountResponse();

        }

        public async Task<AccountResponse> UpdateAccountPatch(int Id, AccountUpdatePatchRequest? accountUpdateRequest)
        {
            Account? accountExist = await _accountRepository.GetAccountById(Id);

            if (accountExist == null)
            {
                throw new Exception("Account not found !");
            }
            ValidationHelper.ModelValidation(accountUpdateRequest);

            accountExist.Status = accountUpdateRequest.Status;
            accountExist.UpdatedAt = DateTime.Now;


            Account result = await _accountRepository.UpdateAccount(accountExist);
            return result.ToAccountResponse();
        }

        public async Task<AccountResponse> UpdatePasswordAccount(int Id, AccountUpdatePasswordRequest? accountUpdateRequest)
        {
            Account? accountExist = await _accountRepository.GetAccountById(Id);

            if (accountExist == null)
            {
                throw new Exception("Account not found !");
            }
            ValidationHelper.ModelValidation(accountUpdateRequest);

            accountExist.UpdatedAt = DateTime.Now;
            var passwordHasher = new PasswordHasher<string>();
            string hashedPassword = passwordHasher.HashPassword(null, accountUpdateRequest.Password);
            accountExist.Password = hashedPassword;

            Account result = await _accountRepository.UpdateAccount(accountExist);
            return result.ToAccountResponse();
        }
    }
}
