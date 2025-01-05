using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;


namespace PrBeleBackend.Core.Services.DiscountServices
{
    public class DiscountGetterServices : IDiscountGetterService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountGetterServices(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<List<DiscountResponse>> GetAllDiscount()
        {
            List<Discount> discounts = await _discountRepository.GetAllDiscount();
            return discounts.Select(c => c.ToDiscountResponse()).ToList();
        }

        public async Task<DiscountResponse?> GetDiscountById(int Id)
        {
            Discount? discount = await _discountRepository.GetDiscountById(Id);
            if (discount == null)
            {
                return null;
            }
            return discount.ToDiscountResponse();
        }

        public async Task<List<DiscountResponse>> GetFilteredDiscount(string searchBy, string? searchString)
        {
            List<Discount> discounts = await _discountRepository.GetAllDiscount();

            if (searchBy == string.Empty || searchString == string.Empty)
            {
                return discounts.Select(c => c.ToDiscountResponse()).ToList();
            }
            switch (searchBy)
            {
                case nameof(Discount.Name):
                    return discounts.Where(a => a.Name.Contains(searchString))
                        .Select(a => a.ToDiscountResponse()).ToList();
                default:
                    return discounts.Select(a => a.ToDiscountResponse()).ToList();
            }
        }
    }
}
