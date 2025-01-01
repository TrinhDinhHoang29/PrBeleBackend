using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllRole();
        public Task<List<Role>> DecentralizeAccount(DecentralizeRequest decentralizeRequest);
        public Task<Role> GetRoleById(int Id);


    }
}
