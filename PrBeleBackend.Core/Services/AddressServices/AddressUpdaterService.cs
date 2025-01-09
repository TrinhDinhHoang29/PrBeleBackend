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
    public class AddressUpdaterService : IAddressUpdaterService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressUpdaterService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressResponse> UpdateAddress(int CustomerId,int AddressId, AddressAddRequest addressAddRequest)
        {
            ValidationHelper.ModelValidation(addressAddRequest);

            AddressCustomer AddressRequest = addressAddRequest.ToAddressCustomer();
            AddressRequest.CustomerId = CustomerId;
            AddressRequest.Id = AddressId;
            AddressCustomer addressCustomer = await _addressRepository.UpdateAddress(AddressRequest);

            return addressCustomer.ToAddressResponse();
        }
    }
}
