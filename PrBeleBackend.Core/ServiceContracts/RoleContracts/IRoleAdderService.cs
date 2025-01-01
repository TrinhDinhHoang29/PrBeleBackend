using PrBeleBackend.Core.DTO.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.RoleContracts
{
    public interface IRoleAdderService
    {
        public Task<List<RoleResponse>> DecentralizeAccount(DecentralizeRequest decentralizeRequest);
    }
}
