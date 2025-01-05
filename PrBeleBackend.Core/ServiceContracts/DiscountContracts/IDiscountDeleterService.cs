using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.DiscountContracts
{
    public interface IDiscountDeleterService
    {
        public Task<bool> DeleteDiscount(int Id);

    }
}
