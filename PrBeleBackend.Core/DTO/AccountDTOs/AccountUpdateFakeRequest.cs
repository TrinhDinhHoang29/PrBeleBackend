﻿using PrBeleBackend.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.AccountDTOs
{
    public class AccountUpdateFakeRequest
    {
        [Required, StringLength(255)]
        public string? FullName { get; set; }

        [Required]
        public int RoleId { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public SexOptions? Sex { get; set; }

        [ StringLength(255)]
        public string? Password { get; set; }

        [StringLength(255), Compare("Password")]
        public string? RePassword { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Status must be either 0 or 1.")]
        public int Status { get; set; }
    }
}
