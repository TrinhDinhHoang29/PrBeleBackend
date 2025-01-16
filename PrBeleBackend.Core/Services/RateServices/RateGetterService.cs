using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.DTO.RateDTOs;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.RateServices
{
    public class RateGetterService : IRateGetterService
    {
        private readonly IRateRepository _rateRepository;
        public RateGetterService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }
        public async Task<List<RateResponse>> GetAllRate()
        {
            List<Rate> rates = await _rateRepository.GetAllRate();
            return rates.Select(r => r.ToRateResponse()).ToList();
        }

        public async Task<List<RateResponse>> GetFilteredRate(string searchBy, string? searchString)
        {
            List<Rate> rates = await _rateRepository.GetAllRate();

            if (searchBy == string.Empty || searchString == string.Empty)
            {
                return rates.Select(c => c.ToRateResponse()).ToList();
            }
            switch (searchBy)
            {
                case "FullName":
                    return rates.Where(a => a.Customer.FullName.ToLower().Contains(searchString.ToLower()))
                        .Select(a => a.ToRateResponse()).ToList();
                default:
                    return rates.Select(a => a.ToRateResponse()).ToList();
            }
        }

        public async Task<RateResponse?> GetRateById(int Id)
        {
            Rate? rate = await _rateRepository.GetRateById(Id);
            if (rate == null)
            {
                return null;
            }
            return rate.ToRateResponse();
        }
    }
}
