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
        public Task<int> GetProductCount();

        public Task<List<ProductResponse>> GetFilteredProduct(Expression<Func<Product, bool>> predicate, int? status);

        public Task<ProductResponse> GetProductById(int id);

        public Task<Product> AddProduct(Product product);

        public Task<Product> UpdateProduct(Product product, int id);

        public Task<Product> ModifyProduct(ProductModifyRequest req, int id);

        public Task<Product> DeleteProduct(int id);
    }
}
