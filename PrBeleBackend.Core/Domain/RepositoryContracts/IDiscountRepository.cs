using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IDiscountRepository
    {
        public Task<List<Discount>> GetAllDiscount();

        public Task<List<Discount>> GetFilteredDiscount(Expression<Func<Discount, bool>> predicate);

        public Task<Discount?> GetDiscountById(int? Id);
        //public Task<Customer?> GetAccountByEmail(string? Email);

        public Task<Discount> AddDiscount(Discount discount);

        public Task<Discount> UpdateDiscount(Discount discount);
        public Task<bool> DeleteDiscountById(int Id);
    }
}
