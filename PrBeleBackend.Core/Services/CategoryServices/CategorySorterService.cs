using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CategoryServices
{
    public class CategorySorterService : ICategorySorterService
    {
        public async Task<List<CategoryResponse>> SortCategories(List<CategoryResponse> categoriesResponse, string? sort, string? order)
        {
            if (sort == string.Empty)
            {
                return categoriesResponse;
            }
            switch (sort)
            {
                case nameof(CategoryResponse.Name):
                    if (order == SortOrderOptions.ASC.ToString())
                        return categoriesResponse.OrderBy(a => a.Name).ToList();
                    else
                        return categoriesResponse.OrderByDescending(a => a.Name).ToList();
                case nameof(CategoryResponse.CreatedAt):
                    if (order == SortOrderOptions.ASC.ToString())
                        return categoriesResponse.OrderBy(a => a.CreatedAt).ToList();
                    else
                        return categoriesResponse.OrderByDescending(a => a.CreatedAt).ToList();
                default:
                    return categoriesResponse;
            }
        }
    }
}
