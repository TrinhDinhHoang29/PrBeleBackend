
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.PermissionDTOs;
using PrBeleBackend.Core.DTO.RolePermissionDTOs;

namespace PrBeleBackend.Core.DTO.RoleDTOs
{
    public class RoleResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<RolePermissionResponse>? RolePermissions { get; set; }

    }
    public static class RoleResponseExtensions
    {
        /// <summary>
        /// Đây là hàm dùng để convert từ Model account sang accountResponse
        /// </summary>
        public static RoleResponse ToRoleResponse(this Role role)
        {
            return new RoleResponse()
            {
                Id = role.id,
                Name = role.Name,
                RolePermissions = role.RolePermissions
                ?.Select(r =>
                {
                    return r.ToRolePermissionResponse();
                }).ToList(),
            };
        }
    }
}
