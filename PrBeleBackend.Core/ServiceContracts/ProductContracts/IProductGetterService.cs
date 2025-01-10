using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ProductContracts
{
    public interface IProductGetterService
    {
        public Task<int> GetProductCount();

        public Task<List<ProductResponse>> GetAllproduct(int? status = 1);

        public Task<List<ProductResponse>> GetFilteredProduct(List<ProductResponse> products, string? searchBy, string? searchStr);

        public Task<ProductResponse> GetProductById(int id);
    }
}
