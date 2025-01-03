using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.RoleDTOs;
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
            List<Role> role = await _context.roles
                .Include(r => r.RolePermissions)
                .ThenInclude(r => r.Permission)
                .ToListAsync();
            return role;
        }
        public async Task<List<Role>> DecentralizeAccount(DecentralizeRequest decentralizeRequest)
        {
            var existingPermissions = _context.rolePermissions.Where(rp => rp.RoleId == decentralizeRequest.RoleId);
            _context.rolePermissions.RemoveRange(existingPermissions);

            var newRolePermissions = decentralizeRequest
                .Permissions
                ?.Select(d =>
                {
                    return new RolePermission()
                    {
                        RoleId = decentralizeRequest.RoleId,
                        PermissionId = d
                    };
                });
            await _context.rolePermissions.AddRangeAsync(newRolePermissions);

            // Lưu thay đổi
            await _context.SaveChangesAsync();

            return await GetAllRole();
        }

        public async Task<Role> GetRoleById(int Id)
        {
            Role role = await _context.roles.Include(r => r.RolePermissions)
                .ThenInclude(r => r.Permission)
                .
                FirstAsync(r => r.id == Id);
            return role;
        }
    }
}
