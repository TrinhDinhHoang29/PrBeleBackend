using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System.Linq.Expressions;


namespace PrBeleBackend.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BeleStoreContext _context;
        public OrderRepository(BeleStoreContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(Order order)
        {
            order.CreatedAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderById(int Id)
        {
            Order? matchingOrder = await _context
               .orders
               .FirstAsync(o => o.Id == Id);
            
             _context.orders.Remove(matchingOrder);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            List<Order> orders = await _context.orders
                  .Include(o => o.Customer)
                 .ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetFilteredOrder(Expression<Func<Order, bool>> predicate)
        {
            List<Order> orders = await _context.orders
                .Include(o =>o.Customer)
               .Where(predicate)
               .ToListAsync();
            return orders;
        }

        public Task<Order?> GetOrderByEmail(string? Email)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> GetOrderById(int? Id)
        {
            Order? order = await _context.orders
                .Include(o => o.Customer)
                .Include(o => o.ProductOrders)
                    .ThenInclude(po => po.Variant)
                        .ThenInclude(v => v.VariantAttributeValues)
                            .ThenInclude(v => v.AttributeValue)
                               .ThenInclude(v => v.AttributeType)
                .Include(o => o.ProductOrders)
                    .ThenInclude(po => po.Variant)
                    .ThenInclude(v=>v.Product)
                    .ThenInclude(v => v.Discount)

               .FirstOrDefaultAsync(o => o.Id == Id);

            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            Order? matchingOrder = await _context
               .orders
               .FirstAsync(o => o.Id == order.Id);

            matchingOrder.FullName = order.FullName;
            matchingOrder.PhoneNumber = order.PhoneNumber;
            matchingOrder.Address = order.Address;
            matchingOrder.TotalMoney = order.TotalMoney;
            matchingOrder.PayMethod = order.PayMethod;
            matchingOrder.ShipDate = order.ShipDate;
            matchingOrder.ReceiveDate = order.ReceiveDate;
            matchingOrder.Status = order.Status;
            matchingOrder.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return matchingOrder;
        }
    }
}
