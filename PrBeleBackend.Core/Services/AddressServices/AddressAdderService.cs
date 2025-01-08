using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AddressDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.AddressContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AddressServices
{
    public class AddressAdderService : IAddressAdderSerivce
    {
        private readonly IAddressRepository _addressRepository;
        public AddressAdderService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressResponse> AddAddress(int IdCustomer, AddressAddRequest addressAddRequest)
        {
            ValidationHelper.ModelValidation(addressAddRequest);
            AddressCustomer addressCustomer = addressAddRequest.ToAddressCustomer();
            addressCustomer.CustomerId = IdCustomer;
            AddressCustomer result = await _addressRepository.AddAddress(addressCustomer);
            return result.ToAddressResponse();
        }
    }
}
