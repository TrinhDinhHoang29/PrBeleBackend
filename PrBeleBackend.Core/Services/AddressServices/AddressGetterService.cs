using PrBeleBackend.Core.DTO.AddressDTOs;
using PrBeleBackend.Core.ServiceContracts.AddressContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AddressServices
{
    public class AddressGetterService : IAddressGetterService
    {
        public Task<List<AddressResponse>> GetAllAddressByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
