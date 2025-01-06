using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllOrder();

        public Task<List<Order>> GetFilteredOrder(Expression<Func<Order, bool>> predicate);

        public Task<Order?> GetOrderById(int? Id);
        public Task<Order?> GetOrderByEmail(string? Email);

        public Task<Order> AddOrder(Order order);

        public Task<Order> UpdateOrder(Order order);

        public Task<bool> DeleteOrderById(int Id);

    }
}
