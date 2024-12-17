using PrBeleBackend.Core.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryUpdaterService
    {
        public Task<CategoryResponse> UpdateCategory(int Id,CategoryUpdateRequest? categoryUpdateRequest);

    }
}
