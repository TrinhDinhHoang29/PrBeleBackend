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

        public async Task<int> GetProductCount()
        {
            return await this._productRepository.GetProductCount();
        }

        public async Task<List<ProductResponse>> GetAllproduct(int? status = 1)
        {
            return await this._productRepository.GetAllProduct(status);
        }

        //public async Task<List<ProductResponse>> FilterProduct

        //public async Task<List<ProductResponse>> GetFilteredProduct(string? searchBy, string? searchStr, int? status = 1)
        //{
        //    switch (searchBy)
        //    {
        //        case nameof(Product.Name):
        //            List<ProductResponse> productsByName = await this._productRepository.GetFilteredProduct(product => product.Name.Contains(searchStr), status);

        //            return productsByName;

        //        default:
        //            List<ProductResponse> products = await this._productRepository.GetFilteredProduct(product => true, status);

        //            return products;
        //    }
        //}

        //public async Task<List<ProductResponse>> GetFilteredProduct(string? searchBy, string? searchStr, int? status = 1)
        //{
        //    switch (searchBy)
        //    {
        //        case nameof(Product.Name):
        //            List<ProductResponse> productsByName = await this._productRepository.FilterProduct(await this._productRepository.GetAllProduct(status), product => product.Name.Contains(searchStr));

        //            return productsByName;

        //        default:
        //            List<ProductResponse> products = await this._productRepository.FilterProduct(await this._productRepository.GetAllProduct(status), product => true);

        //            return products;
        //    }
        //}

        public async Task<List<ProductResponse>> GetFilteredProduct(List<ProductResponse> products, string? searchBy, string? searchStr)
        {
            switch (searchBy)
            {
                case nameof(Product.Name):
                    List<ProductResponse> productsByName = await this._productRepository.FilterProduct(products, product => product.Name.Contains(searchStr));

                    return productsByName;

                case "TagId":
                    List<ProductResponse> productsByTagId = await this._productRepository.FilterProduct(products, product => this._productRepository.IsHaveTag(product.Id, Convert.ToInt32(searchStr)));

                    return productsByTagId;

                case "AttributeTypeId":
                    List<ProductResponse> productsByAttTypId = await this._productRepository.FilterProduct(products, product => this._productRepository.IsHaveAttributeType(product.Id, Convert.ToInt32(searchStr)));

                    return productsByAttTypId;

                case "Color":
                case "Size":
                    List<ProductResponse> productsByAttValId = await this._productRepository.FilterProduct(products, product => this._productRepository.IsHaveAttributeValue(product.Id, searchStr));

                    return productsByAttValId;

                default:
                    List<ProductResponse> productsById = await this._productRepository.FilterProduct(products, product => true);

                    return productsById;
            }
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            ProductResponse product = await this._productRepository.GetProductById(id);

            return product;
        }
    }
}
