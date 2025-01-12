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
        public async Task<Customer> AddCustomer(Customer customer)
        {
            Customer? emailExist = await _context.customers.FirstOrDefaultAsync(a => a.Email == customer.Email);
            if (emailExist != null)
            {
                throw new Exception("Email is exist. !");
            }
            customer.Status = 1;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            customer.Deleted = false;
         
            await _context.customers.AddAsync(customer);
           
            await _context.SaveChangesAsync();
            await _context.carts.AddAsync(new Cart
            {
                UserId = customer.Id,
                TotalMoney = 0,
            });
            await _context.SaveChangesAsync();

            return customer;
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

        public async Task<Customer?> GetCustomerByEmail(string? Email)
        {
            Customer? customer = await _context.customers
                .Where(c => c.Deleted == false)
                .FirstOrDefaultAsync(c => c.Email == Email);

            return customer;
        }

        public async Task<Customer?> GetCustomerById(int? Id)
        {
            Customer? customer = await _context.customers
                .Where(c => c.Deleted == false)
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
            matchingCustomer.RefreshToken = customer.RefreshToken;
            matchingCustomer.RefreshTokenExpirationDateTime = customer.RefreshTokenExpirationDateTime;

            await _context.SaveChangesAsync();

            return matchingCustomer;
        }
    }
}
