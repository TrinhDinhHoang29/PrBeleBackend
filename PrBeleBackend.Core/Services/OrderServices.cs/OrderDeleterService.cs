using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.OrderServices.cs
{
    public class OrderDeleterService : IOrderDeleterService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderDeleterService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> DeleteOrder(int Id)
        {
            Order? matchingOrder= await _orderRepository.GetOrderById(Id);

            if (matchingOrder == null)
            {
                return false;
            }
            bool result = await _orderRepository.DeleteOrderById(Id);
            return result;
        }
    }
}
