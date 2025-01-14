using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.RateDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class RateController : ControllerBase
    {
        private readonly BeleStoreContext _dbContext;
        private readonly IRateGetterService _rateGetterService;

        public RateController(BeleStoreContext dbContext,IRateGetterService rateGetterService)
        {
            _dbContext = dbContext;
            _rateGetterService = rateGetterService;
        }

        [HttpGet("rated")]
        public async Task<IActionResult> Get() {
            try
            {
                int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                List<Rate> rates = await _dbContext.rates
                .Include(r => r.Product)
                .Include(r => r.Account)
                .Include(r => r.Customer)
                .Where(r => r.UserId == customerId)
                .Where(r => r.Deleted == false && r.UserType != "Admin")
                .ToListAsync();
                foreach (var rate in rates)
                {
                    if (rate.ReferenceRateId > 0)
                    {
                        rate.RateReference = await _dbContext.rates
                            .FirstOrDefaultAsync(r => r.Id == rate.ReferenceRateId);
                    }
                }
                List<RateResponse> rateResponses = rates.Select(r => r.ToRateResponse()).ToList();

                return Ok(new
                {
                    status = 200,
                    items = rateResponses,
                    message = "Data fetched successfully."
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
        [HttpPost]  
        public async Task<IActionResult> Post(RateAddRequest rateAdd)
        {
            int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            ProductOrder? rateExist = await _dbContext.productOrders
                .Include(po => po.Order)
                .Include(po => po.Variant)
                .Where(o => o.Order.UserId == customerId && o.IsRating == false)
                .FirstOrDefaultAsync(po => po.OrderId == rateAdd.OrderId && po.Variant.ProductId == rateAdd.ProductId);
            if(rateExist == null)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Request invalid."
                });
            }
            rateExist.IsRating = true;
            Rate rate = new Rate
            {
                UserType = "Customer",
                ProductId = rateAdd.ProductId,
                Content = rateAdd.Content,
                UserId = customerId,
                Star = rateAdd.Star,
                ReferenceRateId = 0,
                Status = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await _dbContext.rates.AddAsync(rate);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                status = 200,
                rate = rate,
                message = "Success"
            });

        }
        [HttpGet("Not-Rated")]
        public async Task<IActionResult> NotRated()
        {
            
            int customerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var rates = await _dbContext.productOrders
                .Include(p => p.Order)
                .Include(p => p.Variant)
                .ThenInclude(v => v.Product)
                .Where(p => p.Order.UserId == customerId && p.IsRating == false)
                .Select(p => new
                {
                    orderId = p.OrderId,
                    pId = p.Variant.ProductId,
                    pName = p.Variant.Product.Name,
                    pImage = p.Variant.Product.Thumbnail,
                }).ToListAsync();
            return Ok(new
            {
                status = 200,
                items = rates,
                message = "Data fetched successfully."
            });
        }
    }
}
