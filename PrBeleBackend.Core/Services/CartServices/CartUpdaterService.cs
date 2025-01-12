using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CartDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.CartContracts;


namespace PrBeleBackend.Core.Services.CartServices
{
    public class CartUpdaterService : ICartUpdaterService
    {
        private readonly ICartRepository _cartRepository;
        public CartUpdaterService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<CartResponse> UpdateCart(int UserId, CartUpdateRequest cartUpdate)
        {
            Cart? cartExist = await _cartRepository.GetDetailCart(UserId);
            if (cartExist == null) {
                throw new Exception("Error can't find Cart.");            
            }
            ValidationHelper.ModelValidation(cartUpdate);
            return cartExist.ToCartResponse();
            
        }
    }
}
