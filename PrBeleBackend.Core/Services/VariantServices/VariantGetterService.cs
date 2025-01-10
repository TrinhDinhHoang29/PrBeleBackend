using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.VariantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;

namespace PrBeleBackend.Core.Services.VariantServices
{
    public class VariantGetterService : IVariantGetterService
    {
        private readonly IVariantRepository _variantRepository;

        public VariantGetterService(IVariantRepository variantRepository)
        {
            this._variantRepository = variantRepository;
        }

        public async Task<decimal> GetVariantCount(int id)
        {
            return await this._variantRepository.GetVariantCountByProductId(id);
        }

        public async Task<List<VariantSizeResponse>> GetVariantByProductIdAndColorId(int productId, int colorId)
        {
            return await this._variantRepository.GetVariantByProductIdAndColor(productId, colorId);
        }

        public async Task<List<VariantResponse>> GetFilteredVariant(int productId = 0, string? searchBy = "", string? searchStr = "")
        {
            if(searchBy == "" || searchStr == "")
            {
                List<VariantResponse> variant = await this._variantRepository.GetFilteredVariant(var => true, productId);

                return variant;
            }

            switch (searchBy)
            {
                case nameof(Variant.Status):
                    {
                        List<VariantResponse> variantByStatus = await this._variantRepository.GetFilteredVariant(var => var.Status == Convert.ToInt32(searchStr), productId);
                        
                        return variantByStatus;
                    }

                case nameof(Variant.Stock):
                    {
                        if (searchStr == "InStock")
                        {
                            List<VariantResponse> variantByStock = await this._variantRepository.GetFilteredVariant(var => var.Stock > 0, productId);

                            return variantByStock;
                        }
                        else
                        {
                            List<VariantResponse> variantByStock = await this._variantRepository.GetFilteredVariant(var => var.Stock < 0, productId);

                            return variantByStock;
                        }
                    }
                default:
                    {
                        List<VariantResponse> variant = await this._variantRepository.GetFilteredVariant(var => true, productId);

                        return variant;
                    }
            }
        }

        public async Task<VariantResponse> GetVariantDetail(int id)
        {
            return await this._variantRepository.GetVariantDetail(id);
        }
    }
}
