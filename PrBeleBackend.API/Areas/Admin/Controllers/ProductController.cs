using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductGetterService _productGetterService;
        private readonly IProductAdderService _productAdderService;
        private readonly IProductUpdaterService _productUpdaterService;
        private readonly IProductModifierService _productModifierService;

        public ProductController(
            IProductGetterService productGetterService, 
            IProductAdderService productAdderService,
            IProductUpdaterService productUpdaterService,
            IProductModifierService productModifierService
        )
        {
            _productGetterService = productGetterService;
            _productAdderService = productAdderService;
            _productUpdaterService = productUpdaterService;
            _productModifierService = productModifierService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] ProductGetterRequest req)
        {
            try
            {
                IEnumerable<ProductResponse> products = await _productGetterService.GetFilteredProduct(req);
                 
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        products = products,
                        pagination = new {
                            skip = req.Skip,
                            limit = req.Limit,
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> Detail(int id)
        {
            ProductResponse product = await this._productGetterService.GetProductById(id);

            return Ok(new
            {
                status = 200,
                data = new
                {
                    product = product
                },
                message = "Get product success !"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductAddRequest req)
        {
            try
            {
                Product product = await this._productAdderService.AddProduct(req);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        product = product
                    },
                    message = "Create product success !"
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

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest req, [FromQuery] int id)
        {
            try
            {
                Product product = await this._productUpdaterService.UpdateProduct(req, id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        product = product
                    },
                    message = "Update product success !"
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

        [HttpPatch("{Id}")]
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
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
                    message = "Delete product success !"
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
