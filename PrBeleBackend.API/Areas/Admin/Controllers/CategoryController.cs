using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryGetterService _categoryGetterService;
        private readonly ICategoryAdderService _categoryAdderService;
        private readonly ICategoryUpdaterService _categoryUpdaterService;
        private readonly ICategoryDeleterService _categoryDeleterService;
        public CategoryController(
            ICategoryGetterService categoryGetterService,
            ICategoryAdderService categoryAdderService,
            ICategoryUpdaterService categoryUpdaterService,
            ICategoryDeleterService categoryDeleterService)
        {
            _categoryGetterService = categoryGetterService;
            _categoryAdderService = categoryAdderService;
            _categoryUpdaterService = categoryUpdaterService;
            _categoryDeleterService = categoryDeleterService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryResponse> categories = await _categoryGetterService.GetAllCategory();
            return Ok(categories);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Detail(int Id)
        {
            try
            {
                CategoryResponse categories = await _categoryGetterService.GetCategoryById(Id);
                return Ok(categories);
            }
            catch (Exception ex) { 
            
               return BadRequest(ex.Message);
            }
 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest categoryAddRequest)
        {
            try
            {
                CategoryResponse category = await _categoryAdderService.AddCategory(categoryAddRequest);
                return Ok(category);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id,CategoryUpdateRequest? categoryUpdateRequest)
        {
            try
            {
                CategoryResponse category = await _categoryUpdaterService
                    .UpdateCategory(Id, categoryUpdateRequest);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                return Ok(await _categoryDeleterService.DeleteCategoryById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }

        }
    }
}
