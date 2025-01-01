using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.RoleDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.PermissionDTOs
{
    public class PermissionResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
    }
    public static class PermissionResponseExtensions
    {
        /// <summary>
        /// Đây là hàm dùng để convert từ Model account sang accountResponse
        /// </summary>
        public static PermissionResponse ToRoleResponse(this Permission permission)
        {
            return new PermissionResponse()
            {
                Id = permission.Id,
                Name = permission.Name,
                Code = permission.Code,
            };
        }
    }
}
