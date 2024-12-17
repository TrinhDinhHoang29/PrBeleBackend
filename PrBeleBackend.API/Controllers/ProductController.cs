using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Infrastructure.DbContexts;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BeleStoreContext _beleStoreContext;
        

        public ProductController(BeleStoreContext beleStoreContext)
        {
            _beleStoreContext = beleStoreContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // Size S,L
            // Color Black, White
            // su
            //var listProducts = _beleStoreContext.products.ToList()
            //.Where(p => !p.Deleted) // Lọc sản phẩm chưa bị xóa
            //.Select(p => new
            //{
            //    ProductId = p.Id,
            //    ProductName = p.Name,
            //    Description = p.Description,
            //    BasePrice = p.BasePrice,
            //    Variants = _beleStoreContext.variants.Where(va=>va.ProductId == p.Id).Include(va=>va.VariantAttributeValues)
            //    .ThenInclude(p=>p.AttributeValue)
            //    .ThenInclude(p=>p.AttributeType).ToList()
            //        .Select(v => new
            //        {
            //            VariantId = v.Id,
            //            Price = v.Price,
            //            Stock = v.Stock,

            //            ListAttribute = v.VariantAttributeValues
            //            .Select(p => new Dictionary<string, string>
            //            {
            //                [p.AttributeValue.AttributeType.Name] = p.AttributeValue.Value
            //            }),

            //        }).ToList()
            //}).ToList();

            return Ok();
        }
    }
}
