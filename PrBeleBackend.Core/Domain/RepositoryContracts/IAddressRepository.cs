using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IAddressRepository
    {
        public Task<List<AddressCustomer>> GetAllAddressById(int Id);

        public Task<List<AddressCustomer>> GetFilteredAddress(Expression<Func<AddressCustomer, bool>> predicate);

        public Task<AddressCustomer?> GetAddressById(int? Id);

        public Task<AddressCustomer> AddAddress(AddressCustomer address);

        public Task<AddressCustomer> UpdateAddress(AddressCustomer address);

        public Task<bool> DeleteAddressById(int Id);
    }
}
