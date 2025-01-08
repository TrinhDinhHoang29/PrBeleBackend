using PrBeleBackend.Core.DTO.AddressDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AddressContracts
{
    public interface IAddressGetterService
    {
        public Task<List<AddressResponse>> GetAllAddressByCustomerId(int customerId);
    }
}
