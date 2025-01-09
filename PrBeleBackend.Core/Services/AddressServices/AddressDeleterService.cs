using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.AddressContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AddressServices
{
    public class AddressDeleterService : IAddressDeleterService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressDeleterService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> DeleteAddress(int AddressId)
        {
            return await _addressRepository.DeleteAddressById(AddressId);
        }
    }
}
