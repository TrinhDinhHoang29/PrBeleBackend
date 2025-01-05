using PrBeleBackend.Core.DTO.DiscountDTOs;

namespace PrBeleBackend.Core.ServiceContracts.DiscountContracts
{
    public interface IDiscountUpdaterService
    {
        public Task<DiscountResponse> UpdateDiscount(int Id, DiscountUpdateRequest? discountUpdateRequest);
        public Task<DiscountResponse> UpdateDiscountPatch(int Id, DiscountUpdatePatchRequest? discountUpdateRequest);
    }
}
