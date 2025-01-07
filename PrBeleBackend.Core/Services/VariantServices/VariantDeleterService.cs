using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.VariantServices
{
    public class VariantDeleterService : IVariantDeleterService
    {
        private readonly IVariantRepository _variantRepository;

        public VariantDeleterService(IVariantRepository variantRepository)
        {
            this._variantRepository = variantRepository;
        }

        public async Task<Variant> DeleteVariant(int id)
        {
            return 
        }
    }
}
