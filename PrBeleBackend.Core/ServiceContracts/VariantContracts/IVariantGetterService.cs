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
        public Task<decimal> GetVariantCount(int id);

        public Task<List<VariantSizeResponse>> GetVariantByProductIdAndColorId(int productId, int colorId);

        public Task<List<VariantResponse>> GetFilteredVariant(int productId, string? searchBy = "", string? searchStr = "");

        public Task<VariantResponse> GetVariantDetail(int id);
    }
}
