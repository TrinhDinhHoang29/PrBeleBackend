using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductGetterService _productGetterService;

        public ProductController(IProductGetterService productGetterService)
        {
            this._productGetterService = productGetterService;
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
                List<ProductResponse> products = await this._productGetterService.GetAllproduct();

                products = products
                    .Where(p => p.Category.Status == 1)
                    .Where(p => p.Status == 1)
                    .ToList();

                if (filter != null)
                {
                    foreach (var set in filter)
                    {
                        if(set.Key != "page" && set.Key != "limit")
                        {
                            products = await this._productGetterService.GetFilteredProduct(products, set.Key, set.Value);
                        }
                    }
                }

                List<ProductResponse> productsPagination = products.Skip(limit * (page - 1)).Take(limit).ToList();

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
    }
}
