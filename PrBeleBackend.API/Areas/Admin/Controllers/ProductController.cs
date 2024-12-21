using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductGetterService _productGetterService;

        public ProductController(IProductGetterService productGetterService)
        {
            _productGetterService = productGetterService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductResponse> products = await _productGetterService.GetAllProduct();

            return Ok(products);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Detail(int id)
        {
            ProductResponse product = await this._productGetterService.GetProductById(id);

            return Ok(product);
        }
    }
}
