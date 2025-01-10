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
            Rate? rateChild = await _context.rates.FirstOrDefaultAsync(r => r.Id == rate.ReferenceRateId);
            if(rateChild != null)
            {
                 _context.rates.Remove(rateChild);
            }
            _context.rates.Remove(rate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Rate>> GetAllRate()
        {
            List<Rate> rates = await _context.rates
                .Include(r => r.Product)
                .Include(r => r.Account)
                .Include(r => r.Customer)
                .Where(r => r.Deleted == false && r.UserType != "Admin")
                .ToListAsync();
            foreach (var rate in rates)
            {
                if (rate.ReferenceRateId>0)
                {
                    rate.RateReference = await _context.rates
                        .FirstOrDefaultAsync(r => r.Id == rate.ReferenceRateId);
                }
            }


            return rates;
        }

        public async Task<Rate?> GetRateById(int? Id)
        {
            Rate? rate = await _context.rates
                .Include(r => r.Product)
                .Include(r => r.Account)
                .Include(r => r.Customer)
                .Where(r => r.Deleted == false && r.UserType != "Admin")
                .FirstOrDefaultAsync(r => r.Id == Id);
            if (rate == null)
                return null;
            if(rate.ReferenceRateId > 0)
            {
                rate.RateReference = await _context.rates
                        .FirstOrDefaultAsync(r => r.Id == rate.ReferenceRateId);
            }
            return rate;
        }

        public async Task<List<Rate>> GetFilteredRate(Expression<Func<Rate, bool>> predicate)
        {
            List<Rate> rates = await _context.rates
                .Include(r => r.Product)
                .Include(r => r.Account)
                .Include(r => r.Customer)
                .Where(r => r.Deleted == false && r.UserType != "Admin")
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
            Rate? rateChild = await _context.rates.FirstOrDefaultAsync(r => r.Id == rateExist.ReferenceRateId);
            if (rateExist.Status == 0)
            {

                if (rateChild != null)
                {
                    rateChild.Status = 0;
                    rateChild.UpdatedAt = DateTime.Now;
                }
            }
            else
            {
                if (rateChild != null)
                {
                    rateChild.Status = 1;
                    rateChild.UpdatedAt = DateTime.Now;
                }
            }
            rateExist.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return rate;
        }

        public async Task<Rate> ReplyRate(int RateParentId, Rate rate)
        {
            Rate? parentRate = await _context.rates.FirstOrDefaultAsync(r => r.Id == RateParentId);
            rate.ProductId = parentRate.ProductId;
            rate.UserType = "Admin";
            rate.ReferenceRateId = 0;
            rate.Star = 0;
            rate.Status = 1;
            rate.CreatedAt = DateTime.Now;
            rate.UpdatedAt = DateTime.Now;
            rate.Deleted = false;
            await _context.rates.AddAsync(rate);
            await _context.SaveChangesAsync();
            parentRate.ReferenceRateId = rate.Id;
            await _context.SaveChangesAsync();
            return rate;
        }
    }
}
