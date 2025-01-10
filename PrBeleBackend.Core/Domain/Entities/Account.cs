using PrBeleBackend.Core.DTO.AccountDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string? FullName { get; set; }

        public int RoleId { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [StringLength(10)]
        public string? Sex { get; set; }

        [Required, StringLength(255)]
        public string? Password { get; set; }

        [Required]
        public int Status { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDateTime { get; set; }
        public List<Rate> Rates { get; set; }
        public Role? Role { get; set; }
    }
    public static class AccountExtensions
    {
        public static Account ToAccount(this AccountAddRequest accountAddRequest)
        {
            return new Account
            {
                FullName = accountAddRequest.FullName,
                RoleId = accountAddRequest.RoleId,
                PhoneNumber = accountAddRequest.PhoneNumber,
                Email = accountAddRequest.Email,
                Password = accountAddRequest.Password,
                Status = accountAddRequest.Status,
                Sex = accountAddRequest.Sex.ToString()
            };
        }
        public static Account ToAccount(this AccountUpdateRequest accountUpdatRequest)
        {
            return new Account
            {
                FullName = accountUpdatRequest.FullName,
                RoleId = accountUpdatRequest.RoleId,
                PhoneNumber = accountUpdatRequest.PhoneNumber,
                Email = accountUpdatRequest.Email,
                //Password = accountUpdatRequest.Password,
                Status = accountUpdatRequest.Status,
                Sex = accountUpdatRequest.Sex.ToString()
            };
        }

    }
}