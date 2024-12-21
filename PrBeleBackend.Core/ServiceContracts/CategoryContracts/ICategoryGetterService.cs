using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryGetterService
    {
        public Task<List<CategoryResponse>> GetAllCategory();

        public Task<CategoryResponse?> GetCategoryById(int Id);

        public Task<List<CategoryResponse>> GetFilteredCategory(string searchBy, string? searchString);

    }
}
