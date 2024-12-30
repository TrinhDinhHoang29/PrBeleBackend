using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;


namespace PrBeleBackend.Core.Services.AccountServices
{
    public class AccountSorterService : IAccountSorterService
    {
        public async Task<List<AccountResponse>> SortAccounts(List<AccountResponse> accountResponse, string? sort, string? order)
        {
            if (sort == string.Empty) {
                return accountResponse;   
            }
            switch (sort) {
                case nameof(Account.FullName):
                    if(order == SortOrderOptions.ASC.ToString())
                        return accountResponse.OrderBy(a => a.FullName).ToList();
                    else
                        return accountResponse.OrderByDescending(a => a.FullName).ToList();
                case nameof(Account.CreatedAt):
                    if (order == SortOrderOptions.ASC.ToString())
                        return accountResponse.OrderBy(a => a.CreatedAt).ToList();
                    else
                        return accountResponse.OrderByDescending(a => a.CreatedAt).ToList();
                default:
                    return accountResponse;
            }
        }
    }
}
