using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.RateDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.RateContracts;


namespace PrBeleBackend.Core.Services.RateServices
{
    public class RateAdderService : IRateAdderService
    {
        private readonly IRateRepository _rateRepository;
        public RateAdderService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }
        public async Task<string> ReplyRate(int userId, ReplyRateRequest replyRateRequest)
        {
             Rate? rateExist = await _rateRepository.GetRateById(replyRateRequest.Id);

            ValidationHelper.ModelValidation(replyRateRequest);
            Rate rateRequest = new Rate { UserId = userId, Content = replyRateRequest.Reply };
            await _rateRepository.ReplyRate(replyRateRequest.Id,rateRequest);
            return "Reply created successfully. !";
        }
        
    }
}
