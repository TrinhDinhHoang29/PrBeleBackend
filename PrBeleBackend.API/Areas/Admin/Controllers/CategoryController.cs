using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.CategoryContracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        private readonly ICategorySorterService _categorySorterService;
        public CategoryController(
            ICategoryGetterService categoryGetterService,
            ICategoryAdderService categoryAdderService,
            ICategoryUpdaterService categoryUpdaterService,
            ICategoryDeleterService categoryDeleterService,
            ICategorySorterService categorySorterService
            )
        {
            _categoryGetterService = categoryGetterService;
            _categoryAdderService = categoryAdderService;
            _categoryUpdaterService = categoryUpdaterService;
            _categoryDeleterService = categoryDeleterService;
            _categorySorterService = categorySorterService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string? field,
            string? query,
            int? status,
            string? sort,
            SortOrderOptions? order = SortOrderOptions.ASC,
            int page = 1,
            int limit = 10
            )
        {
            List<CategoryResponse> categories = await _categoryGetterService.GetFilteredCategory(field,query);
            categories = categories
               .Where(a => status == 0 || status == 1 ? a.Status == status : true)
               .Skip(limit * (page - 1)).Take(limit).ToList();

            categories = await _categorySorterService.SortCategories(categories,sort,order.ToString());

            List<CategoryResponse> all = await _categoryGetterService.GetAllCategory();
            int totalCategories = all.Count();

            var data = categories.Select(category => new
            {
                Id = category.Id,
                Name = category.Name,
                ReferenceCategory = all.FirstOrDefault(item=>item.Id == category.ReferenceCategoryId),
                Status = category.Status,
                Slug = category.Slug,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
            });

            return Ok(new
            {
                status = 200,
                data = new
                {
                    categories = data,
                    pagination = new
                    {
                        currentPage = page,
                        totalPages = totalCategories / limit,
                        totalRecords = totalCategories
                    }
                },
                message = "Data fetched successfully."
            });
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Detail(int Id)
        {
            try
            {
                CategoryResponse? categories = await _categoryGetterService.GetCategoryById(Id);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        categories = categories,
                    },
                    message = "Successful !"
                });
            }
            catch (Exception ex) { 
            
               return BadRequest(new
               {
                   status = 200,
                   data = new
                   {
                       
                   },
                   message = ex.Message
               });
            }
 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest categoryAddRequest)
        {
            try
            {
                CategoryResponse category = await _categoryAdderService.AddCategory(categoryAddRequest);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        category = category,
                    },
                    message = "Successful !"
                });
            }
            catch (Exception ex) {
                return BadRequest(new
                {
                    status = 404,
                    data = new
                    {

                    },
                    message = ex.Message
                });

            }

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id,CategoryUpdateRequest? categoryUpdateRequest)
        {
            try
            {
                CategoryResponse category = await _categoryUpdaterService
                    .UpdateCategory(Id, categoryUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        category = category,
                    },
                    message = "Successful !"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 404,
                    data = new
                    {

                    },
                    message = ex.Message
                });
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                bool result = await _categoryDeleterService.DeleteCategoryById(Id);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                    },
                    message = result.ToString()
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    status = 404,
                    data = new
                    {

                    },
                    message = ex.Message
                });  
            }

        }
    }
}
