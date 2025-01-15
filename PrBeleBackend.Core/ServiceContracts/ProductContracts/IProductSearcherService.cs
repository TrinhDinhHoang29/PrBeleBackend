using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ProductContracts
{
    public interface IProductSearcherService
    {

        public Task<List<Product>> SearchProduct(string searchName, int page = 1, int limit = 10);
    }
}
