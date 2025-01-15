using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryGetterService _categoryGetterService;
        public CategoryController(ICategoryGetterService categoryGetterService)
        {
            _categoryGetterService = categoryGetterService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            List<CategoryResponse> categories = await _categoryGetterService.GetAllCategory();
            List<CategoryResponse> parentCategories = await _categoryGetterService.GetFilteredCategory("ReferenceCategoryId","0");
            var result = parentCategories.Where(r => r.Status == 1 ).Select(category =>
            {
                return new
                {
                    Id = category.Id,
                    Name = category.Name,
                    Slug = category.Slug,
                    referenceCategory = categories
                    .Where(r => r.Status == 1)
                    .Where(c => c.ReferenceCategoryId == category.Id).Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Slug = c.Slug,
                    })
                };
            });
            return Ok(new
            {
                status = 200,
                data = new
                {
                    categories = result
                },
                message = "Data fetched successfully."
            }); 
        }
    }
}
