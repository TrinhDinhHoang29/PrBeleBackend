using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AddressContracts
{
    public interface IAddressDeleterService
    {
        public Task<bool> DeleteAddress(int AddressId);
    }
}
