using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CartDTOs;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.DTO.RateDTOs;
using PrBeleBackend.Core.ServiceContracts.CartContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductGetterService _productGetterService;
        private readonly IProductModifierService _productModifierService;
        private readonly IProductSearcherService _productSearcherService;
        private readonly ICartGetterService _cartGetterService;
        private readonly BeleStoreContext _beleStoreContext;
        private readonly IRateRepository _rateRepository;

        public ProductController(
            IProductGetterService productGetterService, 
            IProductModifierService productModifierService,
            IProductSearcherService productSearcherService,
            BeleStoreContext beleStoreContext,
            IRateRepository rateRepository
        )
        {
            this._productGetterService = productGetterService;
            this._productModifierService = productModifierService;
            this._productSearcherService = productSearcherService;
            _beleStoreContext = beleStoreContext;
            _rateRepository = rateRepository;
        }

        [HttpGet("wishlish")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetWishList(int page = 1, int limit = 10)
        {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                List<ProductResponse> productResponses = await this._productGetterService.GetWishList(customerId);

                productResponses = productResponses
                    .Where(p => p.CategoryStatus == 1)
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

        [HttpPatch("wishlist/{productId}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ModifyWishList(int productId, string actionWishList)
        {
            try
            {
                //int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                int customerId = 1;

                bool res = await this._productModifierService.ModifyWishList(customerId, productId, actionWishList);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        
                    },
                    message = "Modify wish list success !"
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

        [HttpGet("maxPrice")]
        public async Task<IActionResult> GetMaxPrice()
        {
            try
            {
                decimal maxPrice = this._beleStoreContext.products
                    .Where(p => p.Deleted == false && p.Status == 1)
                    .Max(p => p.BasePrice);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        maxPrice = maxPrice
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

        [HttpGet]
        public async Task<IActionResult> GetFilteredProduct(
            [FromQuery] Dictionary<string, string>? filter,
            int page = 1,
            int limit = 10
        )
        {
            try
            {
                List<ProductResponse> productResponses = await this._productGetterService.GetAllProductClient();

                productResponses = productResponses
                    .Where(p => p.CategoryStatus == 1)
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

                int totalPage = 0;

                if(productResponse.Count < limit)
                {
                    totalPage = 1;
                }
                else if(productResponse.Count > limit)
                {
                    totalPage = page + 1;
                }

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        searchedProducts = productResponse,
                        pagination = new { 
                            currentPage = page,
                            totalPage = totalPage
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

        [HttpGet("Detail/{slug}")]
        public async Task<IActionResult> HoangDetail(string slug)
        {

            var rateResponses = await _beleStoreContext.rates
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Where(r => r.Status == 1 && r.Product.Slug == slug)
                .Select(r => new {
                    FullName = r.Customer.FullName,
                    Star = r.Star,
                    Content = r.Content,
                    CreatedAt = r.CreatedAt.ToString("dd/MM/yyyy"),

                }).ToListAsync();

            var productExist = await _beleStoreContext.products
                .Include(p => p.Variants)
                .ThenInclude(v => v.VariantAttributeValues)
                .ThenInclude(vav => vav.AttributeValue)
                .ThenInclude(av => av.AttributeType)
                .Include(v => v.Discount)
                .Include(v => v.Rates)
                .Include(p => p.WishList)
                .ThenInclude(v => v.Customer)
                .Where(p => p.Status == 1)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    View = p.View,
                    Like = p.Like,
                    CategoryId = p.CategoryId,
                    Discount = p.Discount.DiscountValue,
                    Description = p.Description,
                    Slug = p.Slug,
                    WishLists = p.WishList.Select(w => w.CustomerId),
                    Variants = p.Variants.Select(v => new
                    {
                        Id = v.Id,
                        Price = v.Price,
                        Thumbnail = v.Thumbnail,
                        Stock = v.Stock,
                        Attributes = v.VariantAttributeValues.Select(e => new Dictionary<string, string?>
                        {
                            { e.AttributeValue.AttributeType.Name, e.AttributeValue.Name },
                            {"Value",e.AttributeValue.Value }
                        }),

                    }),
                    Rates = rateResponses
                })
                .FirstOrDefaultAsync(p => p.Slug == slug);
                
            if(productExist == null)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Can't find product from slug!." 
                });
            }

            return Ok(new
            {
                status = 200,
                data = new
                {
                    product = productExist
                },
                message = "Fetch successful."
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
