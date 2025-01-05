using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.DiscountContracts
{
    public interface IDiscountAdderService
    {
        public Task<DiscountResponse> AddDiscount(DiscountAddRequest discountAddRequest);

    }
}
