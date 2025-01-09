using PrBeleBackend.Core.DTO.AddressDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AddressContracts
{
    public interface IAddressAdderSerivce
    {
        public Task<AddressResponse> AddAddress(int IdCustomer, AddressAddRequest addressAddRequest);
    }
}
