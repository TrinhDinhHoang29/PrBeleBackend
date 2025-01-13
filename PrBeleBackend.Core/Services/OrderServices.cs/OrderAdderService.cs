using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.OrderServices.cs
{
    public class OrderAdderService : IOrderAdderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderAdderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<OrderResponse> AddOrder(OrderAddRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
