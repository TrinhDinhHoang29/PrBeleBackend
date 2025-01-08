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

        public async Task<List<VariantResponse>> GetFilteredVariant(VariantGetterRequest req)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            PaginationResponse pagRes = await PaginationHelper.Handle(req.Page, req.Limit, await this._variantRepository.GetVariantCountByProductId(req.ProductId));

            switch (req.SearchBy)
            {
                case nameof(Variant.Status):
                    {
                        List<VariantResponse> variantByStatus = await this._variantRepository.GetFilteredVariant(pagRes, var => var.Status == Convert.ToInt32(req.SearchStr), req.ProductId);
                        
                        return variantByStatus;
                    }

                case nameof(Variant.Stock):
                    {
                        if (req.SearchStr == "InStock")
                        {
                            List<VariantResponse> variantByStock = await this._variantRepository.GetFilteredVariant(pagRes, var => var.Stock > 0, req.ProductId);

                            return variantByStock;
                        }
                        else
                        {
                            List<VariantResponse> variantByStock = await this._variantRepository.GetFilteredVariant(pagRes, var => var.Stock < 0, req.ProductId);

                            return variantByStock;
                        }
                    }
                default:
                    {
                        List<VariantResponse> variant = await this._variantRepository.GetFilteredVariant(pagRes, var => true, req.ProductId);

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
