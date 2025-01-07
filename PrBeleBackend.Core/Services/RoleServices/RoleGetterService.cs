using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.RoleDTOs;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.RoleServices
{
    public class RoleGetterService : IRoleGetterService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleGetterService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<List<RoleResponse>> GetAllRole()
        {
            List<Role> roles = await _roleRepository.GetAllRole();
            return roles.Select(role => role.ToRoleResponse()).ToList();
        }

        public async Task<RoleResponse> GetRoleById(int Id)
        {
            Role role = await _roleRepository.GetRoleById(Id);
            return role.ToRoleResponse();
        }
    }
}
