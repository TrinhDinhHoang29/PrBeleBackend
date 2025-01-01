using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.RoleDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.RoleServices
{
    public class RoleAdderService : IRoleAdderService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleAdderService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<List<RoleResponse>> DecentralizeAccount(DecentralizeRequest decentralizeRequest)
        {
            Role? roleExist = await _roleRepository.GetRoleById(decentralizeRequest.RoleId);
            if (roleExist == null) { 
                throw new ArgumentNullException(nameof(roleExist));
            }
            
            ValidationHelper.ModelValidation(decentralizeRequest);
            List<Role> roles = await _roleRepository.DecentralizeAccount(decentralizeRequest);
            List<RoleResponse> rolesResponse = roles.Select(r => r.ToRoleResponse()).ToList();
            return rolesResponse;
        }
    }
}
