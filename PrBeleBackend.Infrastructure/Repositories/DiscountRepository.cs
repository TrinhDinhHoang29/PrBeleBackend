using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly BeleStoreContext _context;

        public DiscountRepository(BeleStoreContext context)
        {
            _context = context;

        }
        public async Task<Discount> AddDiscount(Discount discount)
        {
            await _context.discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> DeleteDiscountById(int Id)
        {
            Discount discount = await _context.discounts.FirstAsync(a => a.Id == Id);
            discount.Deleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Discount>> GetAllDiscount()
        {
            List<Discount> discounts = await _context.discounts
               .Where(a => a.Deleted == false)
               .ToListAsync();
            return discounts;
        }

        public async Task<Discount?> GetDiscountById(int? Id)
        {
            Discount? discount = await _context.discounts
               .Where(a => a.Deleted == false)
               .FirstOrDefaultAsync(a => a.Id == Id);
            return discount;
        }

        public async Task<List<Discount>> GetFilteredDiscount(Expression<Func<Discount, bool>> predicate)
        {
            List<Discount> discounts = await _context.discounts
              .Where(a => a.Deleted == false)
              .Where(predicate)
              .ToListAsync();
            return discounts;
        }

        public async Task<Discount> UpdateDiscount(Discount discount)
        {
            Discount? matchingDiscount = await _context
            .discounts
               .FirstAsync(a => a.Id == discount.Id);
            matchingDiscount.Name = discount.Name;
            matchingDiscount.ExpireDate = discount.ExpireDate;
            matchingDiscount.DiscountValue = discount.DiscountValue;
            matchingDiscount.Status = discount.Status;
            matchingDiscount.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return matchingDiscount;
        }
    }
}
