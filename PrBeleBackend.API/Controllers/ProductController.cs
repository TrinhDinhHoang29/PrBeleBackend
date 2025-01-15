using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductGetterService _productGetterService;
        private readonly IProductModifierService _productModifierService;
        private readonly IProductSearcherService _productSearcherService;

        public ProductController(
            IProductGetterService productGetterService, 
            IProductModifierService productModifierService,
            IProductSearcherService productSearcherService
        )
        {
            this._productGetterService = productGetterService;
            this._productModifierService = productModifierService;
            this._productSearcherService = productSearcherService;
        }

        [HttpGet("wishlish")]
        public async Task<IActionResult> GetWishList(int page = 1, int limit = 10)
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                List<ProductResponse> productResponses = await this._productGetterService.GetWishList(customerId);

                productResponses = productResponses
                    .Where(p => p.Category.Status == 1)
                    .Where(p => p.Status == 1)
                    .ToList();

                List<ProductResponse> productsPagination = productResponses.Skip(limit * (page - 1)).Take(limit).ToList();

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        products = productsPagination,
                        pagination = new
                        {
                            currentPage = page,
                            totalPage = Math.Ceiling(Convert.ToDecimal(productResponses.Count()) / limit)
                        }
                    },
                    message = "Get wishlist success !"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }

            [HttpGet]
        public async Task<IActionResult> GetFilteredProduct(
            Dictionary<string, string>? filter,
            int page = 1,
            int limit = 10
        )
        {
            try
            {
                List<ProductResponse> productResponses = await this._productGetterService.GetAllProductClient();

                productResponses = productResponses
                    .Where(p => p.Category.Status == 1)
                    .Where(p => p.Status == 1)
                    .ToList();

                if (filter != null)
                {
                    foreach (var set in filter)
                    {
                        if (set.Key != "page" && set.Key != "limit")
                        {
                            productResponses = await this._productGetterService.GetFilteredProduct(productResponses, set.Key, set.Value);
                        }
                    }
                }

                List<ProductResponse> productsPagination = productResponses.Skip(limit * (page - 1)).Take(limit).ToList();

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        products = productsPagination,
                        pagination = new
                        {
                            currentPage = page,
                            totalPage = Math.Ceiling(Convert.ToDecimal(productResponses.Count()) / limit)
                        }
                    },
                    message = "Get products success !"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }

        [HttpGet("search/{searchName}")]
        public async Task<IActionResult> SearchProduct(
            string searchName,
            int page = 1,
            int limit = 10
        )
        {
            try
            {
                List<ProductResponse> productResponse = await this._productSearcherService.SearchProduct(searchName, page, limit);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        searchedProducts = productResponse,
                        pagination = new { 
                            currentPage = page,
                            totalPage = page + 1
                        }
                    },
                    message = "Search product success !"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            ProductResponse? productResponse = await this._productGetterService.ProductDetailClient(null, slug);

            return Ok(new
            {
                status = 200,
                data = new
                {
                    product = productResponse
                },
                message = "Get product success !"
            });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Modify([FromBody] ProductModifyRequest req, int id)
        {
            try
            {
                Product product = await this._productModifierService.ModifyProduct(req, id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        product = product
                    },
                    message = "Modify product success !"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }
    }
}
