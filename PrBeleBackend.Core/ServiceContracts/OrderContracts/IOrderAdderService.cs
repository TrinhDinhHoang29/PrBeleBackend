using PrBeleBackend.Core.DTO.OrderDTOs;


namespace PrBeleBackend.Core.ServiceContracts.OrderContracts
{
    public interface IOrderAdderService
    {
        public Task<OrderResponse> AddOrder(OrderAddRequest request);
    }
}
