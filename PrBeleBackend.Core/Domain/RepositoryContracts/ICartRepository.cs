using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface ICartRepository
    {
        public Task<Cart> AddCart(Cart cart);
        public Task<Cart> UpdateCart(Cart cart);
        public Task<Cart?> GetDetailCart(int UserId);
        public Task<bool> DeleteCart(int UserId);
    }
}
