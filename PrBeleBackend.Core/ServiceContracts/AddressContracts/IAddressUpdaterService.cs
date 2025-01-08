using PrBeleBackend.Core.DTO.AddressDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AddressContracts
{
    public interface IAddressUpdaterService
    {
        public Task<AddressResponse> UpdateAddress(int CustomerId, int AddressId,AddressAddRequest addressAddRequest);
    }
}
