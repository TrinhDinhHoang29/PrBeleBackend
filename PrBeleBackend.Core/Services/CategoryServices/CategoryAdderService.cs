using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CategoryServices
{
    public class CategoryAdderService : ICategoryAdderService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAdderService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponse> AddCategory(CategoryAddRequest? categoryAddRequest)
        {
            if(categoryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(categoryAddRequest)); 
            }
            //check CategoryParent
            if(categoryAddRequest.ReferenceCategoryId > 0)
            {
                Category category = await _categoryRepository.GetCategoryById(categoryAddRequest.ReferenceCategoryId);
                if (category == null) { 
                    throw new ArgumentNullException(nameof(category.ReferenceCategoryId));                
                }
            }


            //Validate model
            ValidationHelper.ModelValidation(categoryAddRequest);

            //Convert slug
            Category CategoryInput = categoryAddRequest.ToCategory();

            CategoryInput.Slug = ConvertToSlugHelper
                .ConvertToUnaccentedSlug(categoryAddRequest.Name);
            CategoryInput.UpdatedAt = DateTime.Now;
            CategoryInput.CreatedAt = DateTime.Now;
            //Add Category 
            Category result = await _categoryRepository
                .AddCategory(CategoryInput);

            return result.ToCategoryResponse();
        }
    }
}
