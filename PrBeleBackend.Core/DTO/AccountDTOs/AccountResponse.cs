using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.RoleDTOs;
using PrBeleBackend.Core.Enums;

namespace PrBeleBackend.Core.DTO.AccountDTOs
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        public int RoleId { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
        public string? Sex { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public RoleResponse? Role { get; set; }
    }
    public static class AccountResponseExtensions
    {
        /// <summary>
        /// Đây là hàm dùng để convert từ Model account sang accountResponse
        /// </summary>
        public static AccountResponse ToAccountResponse(this Account account)
        {
            return new AccountResponse()
            {
                Id = account.Id,
                FullName = account.FullName,
                RoleId = account.RoleId,
                PhoneNumber = account.PhoneNumber,
                Email = account.Email,
                Sex = account.Sex,
                Status = account.Status,
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt,
                Role  = account.Role?.ToRoleResponse()
            };
        }
    }
}
