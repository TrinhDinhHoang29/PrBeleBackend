using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CategoryServices
{
    public class CategoryGetterService : ICategoryGetterService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetterService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryResponse>> GetAllCategory()
        {
            List<Category> categories = await _categoryRepository.GetAllCategory();

            return categories.Select(category => category.ToCategoryResponse()).ToList();
        }

        public async Task<CategoryResponse> GetCategoryById(int Id)
        {
            //throw new NotImplementedException();
            Category? category = await _categoryRepository.GetCategoryById(Id);
            if (category == null)
            {
                throw new NullReferenceException($"Category with Id = {Id} not found");
            }
            Category? resultUpdate = await _categoryRepository.UpdateCategory(category);
            return resultUpdate.ToCategoryResponse();
        }

        public async Task<List<CategoryResponse>> GetFilteredCategory(string? searchBy, string? searchString)
        {
            List<Category> categories = await _categoryRepository.GetAllCategory();

            if (searchBy==string.Empty || searchString == string.Empty)
            {

                return categories.Select(category => category.ToCategoryResponse()).ToList();
            }
            switch (searchBy)
            {
                case nameof(Category.Name):
                    List<Category> resultFilteredCategoryByName = await _categoryRepository
                        .GetFilteredCategory(category => category.Name.Contains(searchString));
                    return resultFilteredCategoryByName
                        .Select(cate=>cate.ToCategoryResponse())
                        .ToList();
                default:
                    return categories
                        .Select(category => category.ToCategoryResponse())
                        .ToList();
            }
        }
    }
}
