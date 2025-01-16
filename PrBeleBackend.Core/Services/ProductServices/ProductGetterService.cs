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

        public async Task<List<ProductResponse>> GetWishList(int customerId)
        {
            return await this._productRepository.GetWishList(customerId);
        }

        public async Task<ProductResponse?> ProductDetailClient(int? id, string? slug)
        {
            return await this._productRepository.ProductDetailClient(id, slug);
        }

        public async Task<ProductResponse?> ProductDetailAdmin(int id)
        {
            return await this._productRepository.ProductDetailAdmin(id);
        }

        public async Task<List<ProductResponse>> GetAllProductClient()
        {
            return await this._productRepository.GetAllProductClient();
        }

        public async Task<List<ProductResponse>> GetAllProductAdmin()
        {
            return await this._productRepository.GetAllProductAdmin();
        }

        public async Task<List<ProductResponse>> GetFilteredProduct(List<ProductResponse> products, string? searchBy = "", string? searchStr = "")
        {
            if(searchStr == null || searchBy == null)
            {
                List<ProductResponse> productsById = await this._productRepository.FilterProduct(products, product => true);

                return productsById;
            }

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

                case "CategoryId":
                    List<ProductResponse> productByCatId = await this._productRepository.FilterProduct(products, product => this._productRepository.IsHaveCategory(product.Id, Convert.ToInt32(searchStr)));

                    return productByCatId;

                case "CategoryRefId":
                    List<ProductResponse> productByCatRefId = await this._productRepository.FilterProduct(products, product => this._productRepository.IsHaveCategoryRef(product.Id, Convert.ToInt32(searchStr)));

                    return productByCatRefId;

                case "Color":
                case "Size":
                    List<ProductResponse> productsByAttValId = await this._productRepository.FilterProduct(products, product => this._productRepository.IsHaveAttributeValue(product.Id, searchStr));

                    return productsByAttValId;
                default:
                    {
                        List<ProductResponse> productsById = await this._productRepository.FilterProduct(products, product => true);

                        return productsById;
                    }
            }
        }
    }
}
