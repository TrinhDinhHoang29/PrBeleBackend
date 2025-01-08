using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.ProductServices
{
    public class ProductSorterService : IProductSorterService
    {
        private readonly IProductRepository _productRepository;

        public ProductSorterService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> SortProducts(IEnumerable<ProductResponse> products, string? sort = "", SortOrderOptions? order = SortOrderOptions.ASC)
        {
            switch (sort)
            {
                case nameof(ProductResponse.CreatedAt):
                    {
                        if(order == SortOrderOptions.ASC)
                        {
                            return products.OrderBy(p => p.CreatedAt).ToList();
                        }
                        else
                        {
                            return products.OrderByDescending(p => p.CreatedAt).ToList();
                        }
                    }
                case nameof(ProductResponse.Name):
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return products.OrderBy(p => p.Name).ToList();
                        }
                        else
                        {
                            return products.OrderByDescending(p => p.Name).ToList();
                        }
                    }
                default:
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return products.OrderBy(p => p.Id).ToList();
                        }
                        else
                        {
                            return products.OrderByDescending(p => p.Id).ToList();
                        }
                    }
            }
        }
    }
}
