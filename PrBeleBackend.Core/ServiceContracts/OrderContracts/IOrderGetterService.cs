using PrBeleBackend.Core.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.OrderContracts
{
    public interface IOrderGetterService
    {
        public Task<List<OrderResponse>> GetAllOrder();

        public Task<OrderResponse?> GetOrderById(int Id);

        public Task<List<OrderResponse>> GetFilteredOrder(string searchBy, string? searchString);

    }
}
