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
    public class AddressRepository : IAddressRepository
    {
        private readonly BeleStoreContext _context;
        public AddressRepository(BeleStoreContext context)
        {
            _context = context;
        }
        public async Task<AddressCustomer> AddAddress(AddressCustomer address)
        {
            _context.addressCustomers.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public Task<bool> DeleteAddressById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressCustomer?> GetAddressById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AddressCustomer>> GetAllAddressById(int Id)
        {
            return await _context.addressCustomers.Where(a => a.CustomerId == Id).ToListAsync();
        }

        public Task<List<AddressCustomer>> GetFilteredAddress(Expression<Func<AddressCustomer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<AddressCustomer> UpdateAddress(AddressCustomer address)
        {
            throw new NotImplementedException();
        }
    }
}
