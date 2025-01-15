using PrBeleBackend.Core.Domain.Entities;
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
        public Task<List<Product>> SearchKeyword(List<string> keywords, int page = 1, int limit = 10);

        public bool IsHaveTag(int productId, int tagId);

        public bool IsHaveAttributeType(int productId, int attTypId);

        public bool IsHaveAttributeValue(int productId, string value);

        public Task<List<Product>> GetProductsWithCondition(int? id, string? slug);

        public List<ProductResponse> SelectProductForClient(List<Product> products);

        public Task<List<ProductResponse>> SelectProductForAdmin(List<Product> products);

        public Task<List<ProductResponse>> FilterProduct(List<ProductResponse> products, Func<ProductResponse, bool> predicate);

        public Task<Product> AddProduct(Product product);

        public Task<Product> UpdateProduct(Product product, int id);

        public Task<Product> ModifyProduct(ProductModifyRequest req, int id);


        public Task<Product> DeleteProduct(int id);
    }
}
