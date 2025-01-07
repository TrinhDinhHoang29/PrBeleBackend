using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.RateDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.RateServices
{
    public class RateUpdaterService : IRateUpdaterService
    {
        private readonly IRateRepository _rateRepository;
        public RateUpdaterService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }
        public async Task<string> UpdateRateStatus(int Id,RateStatusUpdateRequest rateStatusUpdate)
        {
            ValidationHelper.ModelValidation(rateStatusUpdate);
            Rate? rateExist = await _rateRepository.GetRateById(Id);
            if (rateExist == null)
            {
                throw new ArgumentNullException(nameof(rateExist));
            }
            rateExist.Id = Id;
            rateExist.Status = rateStatusUpdate.Status;
            Rate result = await _rateRepository.UpdateRate(rateExist);
            return "Rating status updated successfully.";
        }
    }
}
