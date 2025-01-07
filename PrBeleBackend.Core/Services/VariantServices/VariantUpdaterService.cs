using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.VariantServices
{
    public class VariantUpdaterService : IVariantUpdaterService
    {
        private readonly IVariantRepository _variantRepository;
        private readonly ICloudinaryContract _cloudinaryService;

        public VariantUpdaterService(IVariantRepository variantRepository, ICloudinaryContract cloudinaryService)
        {
            this._variantRepository = variantRepository;
            this._cloudinaryService = cloudinaryService;
        }

        public async Task<Variant> UpdateVariant(VariantUpdaterRequest req, int id)
        {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            Variant variant = req.ToVariant();

            if(req.VariantFile != null)
            {
                variant.Thumbnail = await this._cloudinaryService.UploadImageAsync(req.VariantFile, "product", 300, 400);
            }

            variant.Deleted = false;
            variant.UpdatedAt = DateTime.Now;

            return await this._variantRepository.UpdateVariant(variant, id);
        }
    }
}
