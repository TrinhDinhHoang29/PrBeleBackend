using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.VariantServices
{
    public class VariantSorterService : IVariantSorterService
    {
        private readonly IVariantRepository _variantRepository;

        public VariantSorterService(IVariantRepository variantRepository)
        {
            this._variantRepository = variantRepository;
        }

        public async Task<IEnumerable<VariantResponse>> SortVariant(IEnumerable<VariantResponse> variants, string? sort = "", SortOrderOptions? order = SortOrderOptions.ASC)
        {
            switch (sort)
            {
                case nameof(VariantResponse.CreatedAt):
                    {
                        if(order == SortOrderOptions.ASC)
                        {
                            return variants.OrderBy(var => var.CreatedAt).ToList();
                        }
                        else
                        {
                            return variants.OrderByDescending(var => var.CreatedAt).ToList();
                        }
                    }
                case nameof(VariantResponse.Price):
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return variants.OrderBy(var => var.Price).ToList();
                        }
                        else
                        {
                            return variants.OrderByDescending(var => var.Price).ToList();
                        }
                    }
                default:
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return variants.OrderBy(var => var.Id).ToList();
                        }
                        else
                        {
                            return variants.OrderByDescending(var => var.Id).ToList();
                        }
                    }
            }
        }
    }
}
