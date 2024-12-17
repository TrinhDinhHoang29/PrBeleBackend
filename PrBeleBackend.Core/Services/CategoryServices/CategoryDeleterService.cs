using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CategoryServices
{
    public class CategoryDeleterService : ICategoryDeleterService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDeleterService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> DeleteCategoryById(int Id)
        {
            return await _categoryRepository.DeleteCategoryById(Id);
        }
    }
}
