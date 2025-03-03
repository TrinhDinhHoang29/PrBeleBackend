﻿using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IProductRepository
    {
        public Task<bool> AddProductToWishList(int customerId, int productId);

        public Task<bool> RemoveProductFromWishList(int customerId, int productId);

        public Task<List<ProductResponse>> GetWishList(int customerId);

        public Task<List<ProductResponse>> SearchProduct(List<string> keywords, int page = 1, int limit = 10);

        public bool IsHaveTag(int productId, int tagId);

        public bool IsHaveAttributeType(int productId, int attTypId);

        public bool IsHaveAttributeValue(int productId, string value);

        public bool IsHaveCategory(int productId, int categoryId);

        public bool IsHaveCategoryRef(int productId, int categoryRefId);

        public bool IsInPriceRange(int productId, decimal minPrice, decimal maxPrice);

        public Task<ProductResponse?> ProductDetailAdmin(int id);

        public Task<ProductResponse?> ProductDetailClient(int? id, string? slug);

        public Task<List<ProductResponse>> GetAllProductClient();

        public Task<List<ProductResponse>> GetAllProductAdmin();

        public Task<List<ProductResponse>> FilterProduct(List<ProductResponse> products, Func<ProductResponse, bool> predicate);

        public Task<Product> AddProduct(Product product, List<string>? keywords);

        public Task<Product> UpdateProduct(Product product, int id);

        public Task<Product> ModifyProduct(ProductModifyRequest req, int id);

        public Task<Product> DeleteProduct(int id);
    }
}
