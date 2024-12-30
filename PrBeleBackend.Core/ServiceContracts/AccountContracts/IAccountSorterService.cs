using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AccountContracts
{
    public interface IAccountSorterService
    {
        public Task<List<AccountResponse>> SortAccounts(List<AccountResponse> accountResponse,string? sort,string? order);
    }
}
