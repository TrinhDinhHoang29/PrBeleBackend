using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;


namespace PrBeleBackend.Core.Services.AccountServices
{
    public class AccountDeleterService : IAccountDeleterService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountDeleterService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> DeleteAccount(int Id)
        {
            Account? matchingAccount = await _accountRepository.GetAccountById(Id);

            if (matchingAccount == null)
            {
                return false;
            }
            bool result = await _accountRepository.DeleteAccountById(Id);
            return result;
        }
    }
}
