using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.CustomerContracts
{
    public interface ICustomerDeleterService
    {
        public Task<bool> DeleteCustomer(int Id);
    }
}
