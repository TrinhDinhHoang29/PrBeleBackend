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

namespace PrBeleBackend.Core.Services.VariantServices
{
    public class VariantModifierService : IVariantModifierService
    {
        private readonly IVariantRepository _variantRepository;

        public VariantModifierService(IVariantRepository variantRepository)
        {
            this._variantRepository = variantRepository;
        }

        public async Task<Variant> ModifyVariant(VariantModifierRequest req, int id)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            return await this._variantRepository.ModifyVariant(req, id);
        }
    }
}
