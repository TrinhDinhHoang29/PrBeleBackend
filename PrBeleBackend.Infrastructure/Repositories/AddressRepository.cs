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
            if(address.IsDefault == true)
            {
                List<AddressCustomer> addressCustomers = await _context
               .addressCustomers
               .Where(a => a.CustomerId == address.CustomerId)
                .ToListAsync();
                foreach (AddressCustomer addressCustomer in addressCustomers)
                {
                    addressCustomer.IsDefault = false;
                }
            }
            address.CreateAt = DateTime.Now;
            address.UpdateAt = DateTime.Now;
            _context.addressCustomers.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteAddressById(int Id)
        {
            AddressCustomer? address = await _context.addressCustomers.FirstOrDefaultAsync(r => r.Id == Id);
            if (address == null)
            {
                return false;
            }
            _context.addressCustomers.Remove(address);
            await _context.SaveChangesAsync();
            return true;
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

        public async Task<AddressCustomer> UpdateAddress(AddressCustomer address)
        {
            //kiểm tra có tồn tại địa chỉ đó hay không ?
            AddressCustomer? addressExist = await _context.addressCustomers.FirstOrDefaultAsync(a => a.Id == address.Id);
            if (addressExist == null)
            {
                throw new ArgumentNullException("Id Address is null");
            }
            //kiểm tra địa chỉ trước đó là mặc định hay k ?      
            if(addressExist.IsDefault == false)
            {
                //Nếu nó không mặc định mà giờ cập nhật thành mặc định thì phải
                if (address.IsDefault == true)
                {
                    AddressCustomer? addressCustomer = await _context
                   .addressCustomers
                   .Where(a => a.CustomerId == address.CustomerId)
                   .FirstOrDefaultAsync(a => a.IsDefault == true);
                    // => cập nhật lại address đang mặc định trước đó
                    if (addressCustomer != null)
                        addressCustomer.IsDefault = false;
                }
            }
            //Nếu nó không mặc định thì thôi cập nhật bth
            addressExist.FullName = address.FullName;
            addressExist.Phone = address.Phone;
            address.Address = address.Address;
            addressExist.UpdateAt = DateTime.Now;
            _context.addressCustomers.Add(addressExist);
            await _context.SaveChangesAsync();
            return addressExist;
        }
    }
}
