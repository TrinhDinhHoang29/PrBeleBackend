using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CartDTOs;
using PrBeleBackend.Core.ServiceContracts.CartContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CartServices
{
    public class CartGetterService : ICartGetterService
    {
        private readonly ICartRepository _cartRepository;
        public CartGetterService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<CartResponse?> GetDetail(int UserId)
        {
            Cart? response = await _cartRepository.GetDetailCart(UserId);
            return response?.ToCartResponse();
        }
    }
}
