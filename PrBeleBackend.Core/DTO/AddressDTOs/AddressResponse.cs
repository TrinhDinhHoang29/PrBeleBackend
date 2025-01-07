using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.AddressDTOs
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
    }
    public static class AddressResponseExtension
    {
        public static AddressResponse ToAddressResponse(this AddressCustomer addressCustomer)
        {
            return new AddressResponse
            {
                Id = addressCustomer.Id,
                Name = addressCustomer.FullName,
                PhoneNumber = addressCustomer.Phone,
                Address = addressCustomer.Address,
                IsDefault = addressCustomer.IsDefault,
            };
        }
    }
}
