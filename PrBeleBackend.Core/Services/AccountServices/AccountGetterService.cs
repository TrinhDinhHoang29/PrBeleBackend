using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;


namespace PrBeleBackend.Core.Services.AccountServices
{
    public class AccountGetterService : IAccountGetterService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountGetterService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async  Task<AccountResponse?> GetAccountByEmail(string Email)
        {
            Account? account = await _accountRepository.GetAccountByEmail(Email);
            if (account == null)
            {
                return null;
            }
            return account.ToAccountResponse();
        }

        public async Task<AccountResponse?> GetAccountById(int Id)
        {
            Account? account = await _accountRepository.GetAccountById(Id);
            if (account == null) {
                return null;
            }
            return account.ToAccountResponse();
        }

        public async Task<List<AccountResponse>> GetAllAccount()
        {
           List<Account> accounts = await _accountRepository.GetAllAccount();
            return accounts.Select(a => a.ToAccountResponse()).ToList();
        }

        public async Task<List<AccountResponse>> GetFilteredAccount(string searchBy, string searchString)
        {
            List<Account> accounts = await _accountRepository.GetAllAccount();

            if (searchBy == string.Empty || searchString == string.Empty)
            {
                return accounts.Select(a => a.ToAccountResponse()).ToList();
            }
            switch (searchBy)
            {
                case nameof(Account.FullName):
                    return accounts.Where(a => a.FullName.ToLower().Contains(searchString.ToLower()))
                        .Select(a => a.ToAccountResponse()).ToList();
                case nameof(Account.Email):
                    return accounts.Where(a => a.Email.ToLower().Contains(searchString.ToLower()))
                        .Select(a => a.ToAccountResponse()).ToList();
                case nameof(Account.PhoneNumber):
                    return accounts.Where(a => a.PhoneNumber.Contains(searchString))
                        .Select(a => a.ToAccountResponse()).ToList();
                default:
                    return accounts.Select(a => a.ToAccountResponse()).ToList();
            }
        }
    }
}
