using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.VariantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.VariantContracts
{
    public interface IVariantGetterService
    {
        public Task<List<VariantResponse>> GetFilteredVariant(VariantGetterRequest req);

        public Task<VariantResponse> GetVariantDetail(int id);
    }
}
