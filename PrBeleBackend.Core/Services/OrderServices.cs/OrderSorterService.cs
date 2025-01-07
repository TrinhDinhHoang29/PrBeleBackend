using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.DTO.OrderDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.OrderContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.OrderServices.cs
{
    public class OrderSorterService : IOrderSorterService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderSorterService(IOrderRepository orderRepository) { 
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderResponse>> SortOrders(List<OrderResponse> orderResponse, string? sort, string? order)
        {
   
                if (sort == string.Empty)
                {
                    return orderResponse;
                }
                switch (sort)
                {
                    case nameof(Order.FullName):
                        if (order == SortOrderOptions.ASC.ToString())
                            return orderResponse.OrderBy(a => a.FullName).ToList();
                        else
                            return orderResponse.OrderByDescending(a => a.FullName).ToList();
                    case nameof(Order.CreatedAt):
                        if (order == SortOrderOptions.ASC.ToString())
                            return orderResponse.OrderBy(a => a.CreatedAt).ToList();
                        else
                            return orderResponse.OrderByDescending(a => a.CreatedAt).ToList();
                    default:
                        return orderResponse;
                }
            
        }
    }
}
