using PrBeleBackend.Core.DTO.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AccountContracts
{
    public interface IAccountAdderService
    {
        public Task<AccountResponse> AddAccount(AccountAddRequest accountAddRequest);
    }
}
