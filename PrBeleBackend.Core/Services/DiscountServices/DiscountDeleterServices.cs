using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;


namespace PrBeleBackend.Core.Services.DiscountServices
{
    public class DiscountDeleterServices : IDiscountDeleterService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountDeleterServices(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<bool> DeleteDiscount(int Id)
        {
            Discount? matchingDiscount= await _discountRepository.GetDiscountById(Id);

            if (matchingDiscount == null)
            {
                return false;
            }
            bool result = await _discountRepository.DeleteDiscountById(Id);
            return result;
        }
    }
}
