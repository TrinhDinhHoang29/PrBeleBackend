using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.OrderContracts
{
    public interface IOrderSorterService
    {
        public Task<List<OrderResponse>> SortOrders(List<OrderResponse> contactResponse, string? sort, string? order);

    }
}
