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

        public Task<List<ProductResponse>> GetFilteredProduct(string? searchBy, string? searchStr, int? status);

        public Task<ProductResponse> GetProductById(int id);
    }
}
