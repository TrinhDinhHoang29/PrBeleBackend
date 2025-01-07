using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.OrderContracts
{
    public interface IOrderDeleterService
    {
        public Task<bool> DeleteOrder(int Id);

    }
}
