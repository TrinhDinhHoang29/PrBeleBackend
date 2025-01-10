using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.AccountDTOs
{
    public class AccountUpdatePasswordRequest
    {
        [Required, StringLength(255)]
        public string? Password { get; set; }

        [Required, StringLength(255), Compare("Password")]
        public string? RePassword { get; set; }
    }
}
