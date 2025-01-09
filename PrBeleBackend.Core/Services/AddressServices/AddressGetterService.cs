using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
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
        private readonly IAddressRepository _addressRepository;
        public AddressGetterService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<List<AddressResponse>> GetAllAddressByCustomerId(int customerId)
        {
            List<AddressCustomer> addressCustomer = await _addressRepository.GetAllAddressById(customerId);
            return addressCustomer.Select(add => add.ToAddressResponse()).ToList();
        }
    }
}
