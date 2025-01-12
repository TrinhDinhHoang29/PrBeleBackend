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
    public class CartAdderService : ICartAdderService
    {
        private readonly ICartRepository _cartRepository;
        public CartAdderService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<CartResponse> AddCart(int UserId)
        {
            Cart cart = new Cart()
            {
                UserId = UserId,
                TotalMoney = 0,
            };
            Cart result = await _cartRepository.AddCart(cart);

            return result.ToCartResponse();
        }
    }
}
