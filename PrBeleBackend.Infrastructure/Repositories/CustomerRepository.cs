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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BeleStoreContext _context;
        public CustomerRepository(BeleStoreContext context)
        {
            _context = context;
        }
        public Task<Customer> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCustomerById(int Id)
        {
            Customer? matchingCustomer = await _context
               .customers
               .FirstAsync(c => c.Id == Id);
            matchingCustomer.Deleted = true;

            await _context.SaveChangesAsync();

            return matchingCustomer.Deleted;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            List<Customer> customers = await _context.customers
                .Where(c => c.Deleted == false)
                .ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetCustomerById(int? Id)
        {
            Customer? customer = await _context.customers
                .FirstOrDefaultAsync(c => c.Id == Id);

            return customer;
        }

        public async Task<List<Customer>> GetFilteredCustomer(Expression<Func<Customer, bool>> predicate)
        {
            List<Customer> customers = await _context.customers
               .Where(predicate)
               .Where(c => c.Deleted == false)
              .ToListAsync();
            return customers;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            
            Customer? matchingCustomer = await _context
                .customers
                .FirstAsync(c => c.Id == customer.Id);
            matchingCustomer.FullName = customer.FullName;
            matchingCustomer.PhoneNumber = customer.PhoneNumber;
            matchingCustomer.Email = customer.Email;    
            matchingCustomer.Sex = customer.Sex;
            matchingCustomer.Birthday = customer.Birthday;
            matchingCustomer.Password = customer.Password;
            matchingCustomer.TotalSpending = customer.TotalSpending;
            matchingCustomer.Status = customer.Status;
            matchingCustomer.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return matchingCustomer;
        }
    }
}
