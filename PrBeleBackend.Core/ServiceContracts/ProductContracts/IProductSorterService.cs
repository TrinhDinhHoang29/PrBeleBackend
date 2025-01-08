using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ProductContracts
{
    public interface IProductSorterService
    {
        public Task<IEnumerable<ProductResponse>> SortProducts(IEnumerable<ProductResponse> products, string? sort = "", SortOrderOptions? order = SortOrderOptions.ASC);
    }
}
