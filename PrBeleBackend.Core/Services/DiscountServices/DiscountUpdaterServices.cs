using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;


namespace PrBeleBackend.Core.Services.DiscountServices
{
    public class DiscountUpdaterServices : IDiscountUpdaterService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountUpdaterServices(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<DiscountResponse> UpdateDiscount(int Id, DiscountUpdateRequest? discountUpdateRequest)
        {
            Discount? discountExist = await _discountRepository.GetDiscountById(Id);

            if (discountExist == null)
            {
                throw new ArgumentNullException("Discount not found !");
            }
            Discount discountRequest = discountUpdateRequest.ToDiscount();
            ValidationHelper.ModelValidation(discountUpdateRequest);
            if (discountUpdateRequest.ExpireDate < DateTime.Now)
            {
                throw new ArgumentException("ExpireDate is error !");
            }
            discountRequest.Id = Id;
            discountRequest.UpdatedAt = DateTime.Now;
            Discount result = await _discountRepository.UpdateDiscount(discountRequest);

            return result.ToDiscountResponse();
        }

        public async Task<DiscountResponse> UpdateDiscountPatch(int Id, DiscountUpdatePatchRequest? discountUpdateRequest)
        {
            Discount? discountExist = await _discountRepository.GetDiscountById(Id);

            if (discountExist == null)
            {
                throw new ArgumentNullException("Discount not found !");
            }
            discountExist.Status = discountUpdateRequest.Status;
            discountExist.UpdatedAt = DateTime.Now;

            ValidationHelper.ModelValidation(discountExist);


            Discount result = await _discountRepository.UpdateDiscount(discountExist);
            return result.ToDiscountResponse();
        }
    }
}
