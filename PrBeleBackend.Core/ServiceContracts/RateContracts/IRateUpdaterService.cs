using PrBeleBackend.Core.DTO.RateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.RateContracts
{
    public interface IRateUpdaterService
    {
        public Task<string> UpdateRateStatus(int Id, RateStatusUpdateRequest rateStatusUpdate);
    }
}
