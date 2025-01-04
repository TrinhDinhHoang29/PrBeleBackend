using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.VariantServices
{
    public class VariantAdderService : IVariantAdderService
    {
        private readonly IVariantRepository _variantRepository;

        public VariantAdderService(IVariantRepository variantRepository)
        {
            this._variantRepository = variantRepository;
        }
    }
}
