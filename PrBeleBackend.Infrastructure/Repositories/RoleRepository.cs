using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BeleStoreContext _context;

        public RoleRepository(BeleStoreContext context) { 
            _context = context;
            
        }
        public async Task<List<Role>> GetAllRole()
        {
            List<Role> role = await _context.roles.ToListAsync();
            return role;
        }
    }
}
