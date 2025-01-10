using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Infrastructure.DbContexts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]/[Action]")]
    [ApiController]
    //[Authorize]
    //[PermissionAuthorize("D-R")]
    public class DashboardController : ControllerBase
    {
        private readonly BeleStoreContext _beleStoreContext;

        public DashboardController(BeleStoreContext beleStoreContext)
        {
            _beleStoreContext = beleStoreContext; 
        }
        [HttpGet]
        public async Task<IActionResult> Cards()
        {
            int countViewProduct = await _beleStoreContext.products.Where(p => p.Deleted == false).SumAsync(p => p.View);
            decimal countProfit= await _beleStoreContext.orders.Where(o => o.Status == 4).SumAsync(p => p.TotalMoney);
            int countProduct = await _beleStoreContext.products.Where(p => p.Deleted == false).CountAsync();
            int countCustomer = await _beleStoreContext.customers.Where(c => c.Deleted == false).CountAsync();
            return Ok(new
            {
                status = 200,
                data = new List<dynamic> {
                    new
                    {
                        title = "Total Views",
                        total = countViewProduct,
                    },
                     new
                    {
                        title = "Total Profit",
                        total = countProfit,
                    }, new
                    {
                        title = "Total Product",
                        total = countProduct,
                    }, new
                    {
                        title = "Total Users",
                        total = countCustomer,
                    },
                },
                message = "Success."
            });
        }
        [HttpGet("{year}")]
        public async Task<IActionResult> Revenue(int year)
        {
            if(year < 0)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Year invalid." 
                });
            }

            List<decimal> total = new List<decimal>();
            for (int i = 1; i <= 12; i++) {

                decimal revenueMonth = await _beleStoreContext.orders
                .Where(o => o.Status == 4)
                .Where(o => o.UpdatedAt.Year == year && o.UpdatedAt.Month == i)
                .SumAsync(o => o.TotalMoney);
                total.Add(revenueMonth);
            }

            return Ok(new
            {
                status = 200,
                data = new
                {
                    year = year,
                    name = "Total Revenue",
                    figures  = total
                }
            });
        }
        [HttpGet("{type}")]
        public async Task<IActionResult> Purchase(DateOptions? type)
        {
            DateTime today = DateTime.Now;
            List<int> total = new List<int>();

            if (type.ToString() == "week")
            {
                // Xác định ngày đầu tuần (Thứ Hai)
                int diff = (int)today.DayOfWeek - 1;
                if (diff < 0) diff = 6; // Nếu là Chủ Nhật, đưa về Thứ Hai tuần trước
                DateTime startOfWeek = today.AddDays(-diff).Date; // Ngày đầu tuần (Thứ Hai)

                for (int i = 0; i <= 6; i++)
                {
                    startOfWeek =startOfWeek.AddDays(i);
                    int countOrder = await _beleStoreContext.orders
                    .Where(o => o.Status == 4)
                    .Where(o => o.UpdatedAt.Day == startOfWeek.Day &&
                    o.UpdatedAt.Month == startOfWeek.Month &&
                    o.UpdatedAt.Year == startOfWeek.Year)
                    .CountAsync();
                    total.Add(countOrder);
                }
               
            }
            else if (type.ToString() == "month")
            {
                int sumDay = DateTime.DaysInMonth(today.Year,today.Month);
                for (int i = 1; i <= sumDay; i++)
                {
                    int countOrder = await _beleStoreContext.orders
                    .Where(o => o.Status == 4)
                    .Where(o => o.UpdatedAt.Day == i &&
                    o.UpdatedAt.Month == today.Month &&
                    o.UpdatedAt.Year == today.Year)
                    .CountAsync();
                    total.Add(countOrder);
                }

            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    int countOrder = await _beleStoreContext.orders
                    .Where(o => o.Status == 4)
                    .Where(o => 
                    o.UpdatedAt.Month == i &&
                    o.UpdatedAt.Year == today.Year
                    )
                    .CountAsync();
                    total.Add(countOrder);
                }
            }
            return Ok(new
            {
                status = 200,
                data = new
                {
                    type = type.ToString(),
                    name = "Count of Purchase",
                    figures = total
                },
                message = "Success."
            });

        }
    }

}
