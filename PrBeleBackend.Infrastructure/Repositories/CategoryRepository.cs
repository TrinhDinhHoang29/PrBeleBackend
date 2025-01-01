using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly BeleStoreContext _context;

        public CategoryRepository(BeleStoreContext context) { 
            _context = context;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.categories
                .Where(category=>category.Deleted==false)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int? Id)
        {
            return await _context
                .categories
                .Where(category => category.Deleted == false)
                .FirstOrDefaultAsync(category => category.Id == Id);
        }

        public async Task<List<Category>> GetFilteredCategory(Expression<Func<Category, bool>> predicate)
        {
            return await _context.categories
                .Where(category => category.Deleted == false)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Category> AddCategory(Category category)
        {
            await _context.categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Category? matchingCategory = await _context
                .categories
                .Where(category => category.Deleted == false)
                .FirstOrDefaultAsync(cate => cate.Id == category.Id);

            if (matchingCategory == null) { 
                throw new ArgumentException(nameof(category));
            }

            matchingCategory.Name = category.Name;
            matchingCategory.Status = category.Status;
            matchingCategory.Slug = category.Slug;
            matchingCategory.ReferenceCategoryId = category.ReferenceCategoryId;
            matchingCategory.CreatedAt = category.CreatedAt;
            matchingCategory.UpdatedAt = category.UpdatedAt;
            matchingCategory.Deleted = category.Deleted;
            await _context.SaveChangesAsync();
            return matchingCategory;
        }

        public async Task<bool> DeleteCategoryById(int Id)
        {
            Category? matchingCategory = await _context
                .categories
                .Where(category => category.Deleted == false)
                .FirstOrDefaultAsync(cate => cate.Id == Id);
            if (matchingCategory == null)
            {
                return false;
            }
            matchingCategory.Deleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
