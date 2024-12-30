
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AccountDTOs;

namespace PrBeleBackend.Core.DTO.RoleDTOs
{
    public class RoleResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
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
                Name = role.Name
            };
        }
    }
}
