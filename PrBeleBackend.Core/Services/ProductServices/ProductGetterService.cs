using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.ProductServices
{
    public class ProductGetterService : IProductGetterService
    {
        private readonly IProductRepository _productRepository;

        public ProductGetterService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<List<ProductResponse>> GetAllProduct()
        {
            List<ProductResponse> products = await this._productRepository.GetAllProduct();

            return products;
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            ProductResponse product = await this._productRepository.GetProductById(id);

            return product;
        }
    }
}
