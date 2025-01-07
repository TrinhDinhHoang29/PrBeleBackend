using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
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

        public Task<List<RateResponse>> GetFilteredRate(string searchBy, string? searchString)
        {
            throw new NotImplementedException();
        }

        public Task<RateResponse?> GetRateById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
