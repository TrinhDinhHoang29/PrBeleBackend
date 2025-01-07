
using PrBeleBackend.Core.Domain.Entities;
using System.Linq.Expressions;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IRateRepository
    {
        public Task<List<Rate>> GetAllRate();

        public Task<List<Rate>> GetFilteredRate(Expression<Func<Rate, bool>> predicate);

        public Task<Rate?> GetRateById(int? Id);

        public Task<Rate> AddRate(Rate rate);
        public Task<Rate> ReplyRate(int RateParentId,Rate rate);


        public Task<Rate> UpdateRate(Rate rate);

        public Task<bool> DeleteRateById(int Id);

    }
}
