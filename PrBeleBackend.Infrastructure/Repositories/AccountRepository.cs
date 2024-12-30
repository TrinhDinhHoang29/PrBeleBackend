using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BeleStoreContext _context;

        public AccountRepository(BeleStoreContext context)
        {
            _context = context;

        }
        public async Task<Account> AddAccount(Account account)
        {
            var role = await _context.roles.FirstOrDefaultAsync(r=> r.id == account.RoleId);
            if(role == null)
            {
                throw new Exception(message: "RoleId is invalid !");
            }
            await _context.accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccountById(int Id)
        {
            Account account = await _context.accounts.FirstAsync(a => a.Id == Id);
            account.Deleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Account?> GetAccountByEmail(string? Email)
        {
            Account? account = await _context.accounts
                .FirstOrDefaultAsync(a => a.Email == Email);
            return account;
        }

        public async Task<Account?> GetAccountById(int? Id)
        {
            Account? account = await _context.accounts
                .Include(a => a.Role)
               .Where(a => a.Deleted == false)
               .FirstOrDefaultAsync(a => a.Id == Id);
            return account;
        }

        public async Task<List<Account>> GetAllAccount()
        {
            List<Account> accounts = await _context.accounts
                .Include(a=>a.Role)
                .Where(a=> a.Deleted == false)
                .ToListAsync();
            return accounts;
        }

        public async Task<List<Account>> GetFilteredAccount(Expression<Func<Account, bool>> predicate)
        {
            List<Account> accounts =  await _context.accounts
               .Include(a => a.Role)
               .Where(a => a.Deleted == false)
               .Where(predicate)
               .ToListAsync();
            return accounts;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            var role = await _context.roles.FirstOrDefaultAsync(r => r.id == account.RoleId);
            if (role == null)
            {
                throw new Exception(message: "RoleId is invalid !");
            }
            Account? matchingAccount = await _context
                .accounts
                .FirstAsync(a => a.Id == account.Id);
            matchingAccount.RoleId = account.RoleId;
            matchingAccount.FullName = account.FullName;
            matchingAccount.PhoneNumber = account.PhoneNumber;
            matchingAccount.Email = account.Email;
            matchingAccount.Status = account.Status;
            matchingAccount.Sex = account.Sex;
            matchingAccount.Password = account.Password;
            matchingAccount.UpdatedAt = account.UpdatedAt;

            await _context.SaveChangesAsync();

            return matchingAccount;
        }
    }
}
