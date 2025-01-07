using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.RateContracts
{
    public interface IRateDeleterService
    {
        public Task<bool> DeleteRate(int Id);
    }
}
