using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategory();

        public Task<List<Category>> GetFilteredCategory(Expression<Func<Category, bool>> predicate);

        public Task<Category?> GetCategoryById(int? Id);

        public Task<Category> AddCategory(Category category);

        public Task<Category> UpdateCategory(Category category);

        public Task<bool> DeleteCategoryById(int Id);
    }
}
