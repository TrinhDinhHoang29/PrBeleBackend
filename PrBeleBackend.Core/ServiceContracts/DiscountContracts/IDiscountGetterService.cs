using PrBeleBackend.Core.DTO.DiscountDTOs;


namespace PrBeleBackend.Core.ServiceContracts.DiscountContracts
{
    public interface IDiscountGetterService
    {
        public Task<List<DiscountResponse>> GetAllDiscount();

        public Task<DiscountResponse?> GetDiscountById(int Id);

        public Task<List<DiscountResponse>> GetFilteredDiscount(string searchBy, string? searchString);
    }
}
