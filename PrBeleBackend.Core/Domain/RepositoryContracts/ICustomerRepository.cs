using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomer();

        public Task<List<Customer>> GetFilteredCustomer(Expression<Func<Customer, bool>> predicate);
        public Task<Customer?> GetCustomerByRefreshToken(string? RefreshToken);

        public Task<Customer?> GetCustomerById(int? Id);
        public Task<Customer?> GetCustomerByEmail(string? Email);

        public Task<Customer> AddCustomer(Customer customer);

        public Task<Customer> UpdateCustomer(Customer customer);

        public Task<bool> DeleteCustomerById(int Id);
    }
}
