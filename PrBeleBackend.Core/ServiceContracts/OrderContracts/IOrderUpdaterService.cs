using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.OrderContracts
{
    public interface IOrderUpdaterService
    {
        public Task<OrderResponse> UpdateStatusOrder(int OrderId);
        public Task<OrderResponse> CancelOrder(int OrderId,int CustomerId);
    }
}
