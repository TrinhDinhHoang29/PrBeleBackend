using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.DTO.RateDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.RateContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.RateServices
{
    public class RateSorterService : IRateSortService
    {
        private readonly IRateRepository _rateRepository;
        public RateSorterService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }
        public async Task<List<RateResponse>> SortRate(List<RateResponse> rateResponses, string? sort, string? order)
        {
            if (sort == string.Empty)
            {
                return rateResponses;
            }
            switch (sort)
            {
                case nameof(RateResponse.Name):
                    if (order == SortOrderOptions.ASC.ToString())
                        return rateResponses.OrderBy(a => a.Name).ToList();
                    else
                        return rateResponses.OrderByDescending(a => a.Name).ToList();
                case nameof(RateResponse.CreatedAt):
                    if (order == SortOrderOptions.ASC.ToString())
                        return rateResponses.OrderBy(a => a.CreatedAt).ToList();
                    else
                        return rateResponses.OrderByDescending(a => a.CreatedAt).ToList();
                case nameof(RateResponse.Star):
                    if (order == SortOrderOptions.ASC.ToString())
                        return rateResponses.OrderBy(a => a.Star).ToList();
                    else
                        return rateResponses.OrderByDescending(a => a.Star).ToList();
                default:
                    return rateResponses;
            }
        }
    }
}
