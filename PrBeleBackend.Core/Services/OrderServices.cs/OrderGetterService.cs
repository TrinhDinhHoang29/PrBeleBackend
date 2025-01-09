using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.OrderServices.cs
{
    public class OrderGetterService : IOrderGetterService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IVariantRepository _variantRepository;
        public OrderGetterService(IOrderRepository orderRepository, IVariantRepository variantRepository)
        {
            _orderRepository = orderRepository;
            _variantRepository = variantRepository;
        }
        public async Task<List<OrderResponse>> GetAllOrder()
        {
            List<Order> orderResponses = await _orderRepository.GetAllOrder();
            return orderResponses.Select(order => order.ToOrderResponse()).ToList();
        }

        public async Task<List<OrderResponse>> GetFilteredOrder(string searchBy, string? searchString)
        {
            List<Order> orders = await _orderRepository.GetAllOrder();

            if (searchBy == string.Empty || searchString == string.Empty)
            {

                return orders.Select(order => order.ToOrderResponse()).ToList();
            }
            switch (searchBy)
            {
                case nameof(Order.FullName):
                    List<Order> resultFilteredOrderByName = await _orderRepository
                        .GetFilteredOrder(order => order.FullName.ToLower().Contains(searchString.ToLower()));
                    return resultFilteredOrderByName
                        .Select(order => order.ToOrderResponse())
                        .ToList();
                case nameof(Order.PhoneNumber):
                    List<Order> resultFilteredOrderByPhone = await _orderRepository
                        .GetFilteredOrder(order => order.PhoneNumber.ToLower().Contains(searchString.ToLower()));
                    return resultFilteredOrderByPhone
                        .Select(order => order.ToOrderResponse())
                        .ToList();
                default:
                    return orders
                        .Select(order => order.ToOrderResponse())
                        .ToList();
            }
        }

        public async Task<OrderResponse?> GetOrderById(int Id)
        {
            Order? orderDetail = await _orderRepository.GetOrderById(Id);
            
            if (orderDetail == null)
            {
                return null;
            }
           
           
            return orderDetail.ToOrderResponse();
        }
    }
}
