using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.DTO.RateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.RateContracts
{
    public interface IRateGetterService
    {
        public Task<List<RateResponse>> GetAllRate();

        public Task<RateResponse?> GetRateById(int Id);

        public Task<List<RateResponse>> GetFilteredRate(string searchBy, string? searchString);
    }
}
