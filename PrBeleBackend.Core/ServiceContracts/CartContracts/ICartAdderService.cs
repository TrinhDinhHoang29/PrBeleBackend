using PrBeleBackend.Core.DTO.CartDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CartContracts
{
    public interface ICartAdderService
    {
        public Task<CartResponse> AddCart(int UserId);
    }
}
