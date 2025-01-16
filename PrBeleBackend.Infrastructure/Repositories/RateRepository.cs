using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly BeleStoreContext _context;
        public RateRepository(BeleStoreContext context)
        {
            _context = context;
        }
        public Task<Rate> AddRate(Rate rate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteRateById(int Id)
        {
            Rate? rate = await _context.rates.FirstOrDefaultAsync(r => r.Id == Id);
            if (rate == null)
            {
                return false;
            }
           
            _context.rates.Remove(rate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Rate>> GetAllRate()
        {
            List<Rate> rates = await _context.rates
                .Include(r => r.Product)
                .Include(r => r.Customer)
                .Where(r => r.Deleted == false)
                .ToListAsync();
     


            return rates;
        }

        public async Task<Rate?> GetRateById(int? Id)
        {
            Rate? rate = await _context.rates
                .Include(r => r.Product)
                .Include(r => r.Customer)
                .Where(r => r.Deleted == false)
                .FirstOrDefaultAsync(r => r.Id == Id);
            if (rate == null)
                return null;
    
            return rate;
        }

        public async Task<List<Rate>> GetFilteredRate(Expression<Func<Rate, bool>> predicate)
        {
            List<Rate> rates = await _context.rates
                .Include(r => r.Product)
                .Include(r => r.Customer)
                .Where(r => r.Deleted == false)
                .Where(predicate)
                .ToListAsync();
            return rates;
        }


        public async Task<Rate> UpdateRate(Rate rate)
        {
            Rate? rateExist = await _context.rates.FirstOrDefaultAsync(r => r.Id == rate.Id);
            if (rateExist == null) { 
                throw new ArgumentNullException(nameof(rate));
            }
            
            rateExist.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return rate;
        }

        public async Task<Rate> ReplyRate(int RateParentId, Rate rate)
        {
            Rate? parentRate = await _context.rates.FirstOrDefaultAsync(r => r.Id == RateParentId);
            rate.ProductId = parentRate.ProductId;
            rate.Star = 0;
            rate.Status = 1;
            rate.CreatedAt = DateTime.Now;
            rate.UpdatedAt = DateTime.Now;
            rate.Deleted = false;
            await _context.rates.AddAsync(rate);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
            return rate;
        }
    }
}
