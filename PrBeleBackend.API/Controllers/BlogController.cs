using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.ServiceContracts.BlogContracts;
using PrBeleBackend.Core.DTO.ProductDTOs;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogGetterService _blogGetterService;

        public BlogController(IBlogGetterService blogGetterService)
        {
            this._blogGetterService = blogGetterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs(string? searchName = "", int page = 1, int limit = 10)
        {
            try
            {
                List<Blog> blogs = await this._blogGetterService.GetBlogs(searchName);

                List<Blog> blogsPagination = blogs.Skip(limit * (page - 1)).Take(limit).ToList();

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        blogs = blogsPagination,
                        pagination = new
                        {
                            currentPage = page,
                            totalPage = Math.Ceiling(Convert.ToDecimal(blogsPagination.Count()) / limit)
                        }
                    },
                    message = "Get blogs success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailBlog(int id)
        {
            try
            {
                Blog blog = await this._blogGetterService.GetBlogById(id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        blog = blog
                    },
                    message = "Get blog success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }
    }
}
