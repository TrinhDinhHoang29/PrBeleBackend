using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AccountContracts
{
    public interface IAccountUpdaterService
    {
        public Task<AccountResponse> UpdateAccount(int Id, AccountUpdateRequest? accountUpdateRequest);
        public Task<AccountResponse> UpdateAccountPatch(int Id, AccountUpdatePatchRequest? accountUpdateRequest);

    }
}
