using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.RateServices
{
    public class RateDeleterService : IRateDeleterService
    {
        private readonly IRateRepository _repository;
        public RateDeleterService(IRateRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteRate(int Id)
        {
            return await _repository.DeleteRateById(Id);
        }
    }
}
