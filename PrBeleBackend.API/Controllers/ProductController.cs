using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;

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

        [HttpGet]
        public async Task<IActionResult> GetFilteredProduct(
            Dictionary<string, string>? filter,
            int page = 1,
            int limit = 10
        )
        {
            try
            {
                List<Product> products = await this._productGetterService.GetProductsWithCondition(null, null);

                List<ProductResponse> productResponses = await this._productGetterService.SelectProductForClient(products);

                productResponses = productResponses
                    .Where(p => p.Category.Status == 1)
                    .Where(p => p.Status == 1)
                    .ToList();

                if (filter != null)
                {
                    foreach (var set in filter)
                    {
                        if(set.Key != "page" && set.Key != "limit")
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
                            totalPage = Math.Ceiling(Convert.ToDecimal(products.Count()) / limit)
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
                List<Product> products = await this._productSearcherService.SearchProduct(searchName, page, limit);

                List<ProductResponse> productResponse = await this._productGetterService.SelectProductForClient(products);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        searchedProducts = productResponse
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
            List<Product> product = await this._productGetterService.GetProductsWithCondition(null, slug);

            ProductResponse? productResponse = (await this._productGetterService.SelectProductForClient(product)).FirstOrDefault();

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
