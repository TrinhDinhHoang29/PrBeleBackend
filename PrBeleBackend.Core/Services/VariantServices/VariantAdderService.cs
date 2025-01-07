using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts;

namespace PrBeleBackend.Core.Services.VariantServices
{
    public class VariantAdderService : IVariantAdderService
    {
        private readonly IVariantRepository _variantRepository;
        private readonly ICloudinaryContract _cloudinaryService;

        public VariantAdderService(IVariantRepository variantRepository, ICloudinaryContract cloudinaryService)
        {
            this._variantRepository = variantRepository;
            this._cloudinaryService = cloudinaryService;
        }

        public async Task<Variant> CreateVariant(VariantAdderRequest req)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            Variant variant = req.ToVariant();

            variant.Thumbnail = await this._cloudinaryService.UploadImageAsync(req.VariantFile, "product", 300, 400);
            variant.Deleted = false;
            variant.CreatedAt = DateTime.Now;
            variant.UpdatedAt = DateTime.Now;

            return await this._variantRepository.CreateVariant(variant);
        }
    }
}
