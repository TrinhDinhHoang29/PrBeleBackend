using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.OrderServices.cs
{
    public class OrderUpdaterService : IOrderUpdaterService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderUpdaterService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderResponse> CancelOrder(int OrderId,int CustomerId)
        {
            Order? orderExist = await _orderRepository.GetOrderById(OrderId);

            if (orderExist == null || orderExist.UserId != CustomerId)
            {
                throw new ArgumentNullException("Order not found !");
            }
            if (orderExist.Status > 1 || orderExist.Status == -1)
            {
                throw new ArgumentNullException("Request invalid !");
            }
            orderExist.Status = -1;

            Order result = await _orderRepository.UpdateOrder(orderExist);
            return result.ToOrderResponse();
        }

        public async Task<OrderResponse> UpdateStatusOrder(int OrderId)
        {
            Order? orderExist = await _orderRepository.GetOrderById(OrderId);

            if (orderExist == null)
            {
                throw new ArgumentNullException("Order not found !");
            }
            if(orderExist.Status == 4 || orderExist.Status == -1)
            {
                throw new ArgumentNullException("Request invalid !");
            }
            orderExist.Status = orderExist.Status + 1;

            Order result = await _orderRepository.UpdateOrder(orderExist);
            return result.ToOrderResponse();
        }
    }
}
