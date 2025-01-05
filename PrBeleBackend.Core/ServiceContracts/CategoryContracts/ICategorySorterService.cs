using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CategoryContracts
{
    public interface ICategorySorterService
    {
        public Task<List<CategoryResponse>> SortCategories(List<CategoryResponse> categoriesResponse, string? sort, string? order);

    }
}
