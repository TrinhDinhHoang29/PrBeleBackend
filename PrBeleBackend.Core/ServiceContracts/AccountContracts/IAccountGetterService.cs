using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AccountContracts
{
    public interface IAccountGetterService
    {
        public Task<List<AccountResponse>> GetAllAccount();
        public Task<AccountResponse?> GetAccountByEmail(string Email);

        public Task<AccountResponse?> GetAccountById(int Id);

        public Task<List<AccountResponse>> GetFilteredAccount(string searchBy, string? searchString);
    }
}
