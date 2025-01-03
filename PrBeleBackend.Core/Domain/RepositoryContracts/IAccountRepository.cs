using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAllAccount();

        public Task<List<Account>> GetFilteredAccount(Expression<Func<Account, bool>> predicate);

        public Task<Account?> GetAccountById(int? Id);
        public Task<Account?> GetAccountByEmail(string? Email);
        public Task<Account?> GetAccountByRefreshToken(string? RefreshToken);

        public Task<Account> AddAccount(Account account);

        public Task<Account> UpdateAccount(Account account);

        public Task<bool> DeleteAccountById(int Id);
    }
}
