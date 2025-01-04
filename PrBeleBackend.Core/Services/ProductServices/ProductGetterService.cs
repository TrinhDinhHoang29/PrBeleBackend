using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.Helpers;

namespace PrBeleBackend.Core.Services.ProductServices
{
    public class ProductGetterService : IProductGetterService
    {
        private readonly IProductRepository _productRepository;

        public ProductGetterService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<List<ProductResponse>> GetFilteredProduct(ProductGetterRequest req)
        {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            PaginationResponse paginationResponse = await PaginationHelper.Handle(req.Skip, req.Limit, await this._productRepository.GetProductCount());

            switch (req.SearchBy)
            {
                case nameof(Product.Name):
                    List<ProductResponse> productsByName = await this._productRepository.GetFilteredProduct(paginationResponse, product => product.Name.Contains(req.SearchStr));

                    return productsByName;

                case nameof(Product.Status):
                    List<ProductResponse> productsByStatus = await this._productRepository.GetFilteredProduct(paginationResponse, product => product.Status == Convert.ToInt32(req.SearchStr));

                    return productsByStatus;

                default:
                    List<ProductResponse> products = await this._productRepository.GetFilteredProduct(paginationResponse, product => true);

                    return products;
            }
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            ProductResponse product = await this._productRepository.GetProductById(id);

            return product;
        }
    }
}
