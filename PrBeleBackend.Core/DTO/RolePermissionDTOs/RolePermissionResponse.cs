using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.PermissionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.RolePermissionDTOs
{
    public class RolePermissionResponse
    {
        public PermissionResponse? Permission { get; set; }
    }
    public static class RolePermissionResponseExtension
    {
        public static RolePermissionResponse ToRolePermissionResponse(this RolePermission rolePermission)
        {
            return new RolePermissionResponse()
            {
                Permission = rolePermission.Permission?.ToRoleResponse(),
            };
        }
       
    }
}
