using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryAdderService
    {
        public Task<CategoryResponse> AddCategory(CategoryAddRequest categoryAddRequest); 
    }
}
