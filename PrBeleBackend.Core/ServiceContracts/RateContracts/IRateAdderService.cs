using PrBeleBackend.Core.DTO.RateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.RateContracts
{
    public interface IRateAdderService
    {
        public Task<string> ReplyRate(int userId, ReplyRateRequest replyRateRequest);
    }
}
