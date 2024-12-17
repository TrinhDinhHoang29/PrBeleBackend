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
    public class CategoryUpdaterService : ICategoryUpdaterService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUpdaterService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponse> UpdateCategory(int Id, CategoryUpdateRequest? categoryUpdateRequest)
        {
            if(categoryUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(categoryUpdateRequest));
            }

            //check CategoryId

            Category? checkCategoryNeedUpdate = await _categoryRepository.GetCategoryById(Id);

            if(checkCategoryNeedUpdate == null)
            {
                throw new ArgumentNullException(nameof(checkCategoryNeedUpdate));
            }

            //check CategoryParent
            if (categoryUpdateRequest.ReferenceCategoryId > 0)
            {
                Category? category = await _categoryRepository.GetCategoryById(categoryUpdateRequest.ReferenceCategoryId);
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category.ReferenceCategoryId));
                }
            }

            //Validate model
            ValidationHelper.ModelValidation(categoryUpdateRequest);


            //Convert slug
            checkCategoryNeedUpdate.Slug = ConvertToSlugHelper
                .ConvertToUnaccentedSlug(categoryUpdateRequest.Name);
            checkCategoryNeedUpdate.Name = categoryUpdateRequest.Name;
            checkCategoryNeedUpdate.Status = categoryUpdateRequest.Status;
            checkCategoryNeedUpdate.ReferenceCategoryId = categoryUpdateRequest.ReferenceCategoryId;
            checkCategoryNeedUpdate.UpdatedAt = DateTime.Now;

            //Update Category 
            Category result = await _categoryRepository
                .UpdateCategory(checkCategoryNeedUpdate);

            return result.ToCategoryResponse();

        }
    
    
    }
}
