using PrBeleBackend.Core.DTO.CartDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CartContracts
{
    public interface ICartGetterService
    {
        public Task<CartResponse?> GetDetail(int UserId);
    }
}
