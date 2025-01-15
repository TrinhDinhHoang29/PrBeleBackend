using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductGetterService _productGetterService;
        private readonly IProductAdderService _productAdderService;
        private readonly IProductUpdaterService _productUpdaterService;
        private readonly IProductModifierService _productModifierService;
        private readonly IProductDeleterService _productDeleterService;
        private readonly IProductSorterService _productSorterService;

        public ProductController(
            IProductGetterService productGetterService, 
            IProductAdderService productAdderService,
            IProductUpdaterService productUpdaterService,
            IProductModifierService productModifierService,
            IProductDeleterService productDeleterService,
            IProductSorterService productSorterService
        )
        {
            _productGetterService = productGetterService;
            _productAdderService = productAdderService;
            _productUpdaterService = productUpdaterService;
            _productModifierService = productModifierService;
            _productDeleterService = productDeleterService;
            _productSorterService = productSorterService;
        }
        [PermissionAuthorize("P-R")]
        [HttpGet]
        public async Task<IActionResult> Index(
            string? sort,
            int? status,
            string? field = "",
            string? query = "",
            SortOrderOptions? order = SortOrderOptions.ASC,
            int page = 1,
            int limit = 10
        )
        {
            try
            {
                IEnumerable<ProductResponse> productResponses = await _productGetterService.GetFilteredProduct(await this._productGetterService.GetAllProductAdmin(), field, query);
                
                if(status != null)
                {
                    productResponses = productResponses.Where(x => x.Status == status);
                }

                IEnumerable<ProductResponse> productPagination = productResponses.Skip(limit * (page - 1)).Take(limit).ToList();

                IEnumerable<ProductResponse> productSorted = await this._productSorterService.SortProducts(productPagination, sort, order);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        products = productSorted,
                        pagination = new {
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

        [PermissionAuthorize("P-R")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            ProductResponse? productResponse =  await this._productGetterService.ProductDetailAdmin(id);

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

        [PermissionAuthorize("P-C")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductAddRequest req)
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
        [PermissionAuthorize("P-U")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest req, int id)
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

        [PermissionAuthorize("P-U")]
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

        [PermissionAuthorize("P-D")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product product = await this._productDeleterService.DeleteProduct(id);

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
