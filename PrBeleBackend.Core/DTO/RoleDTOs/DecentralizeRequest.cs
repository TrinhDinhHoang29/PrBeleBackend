using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.RoleDTOs
{
    public class DecentralizeRequest
    {
        [Required]
        public int RoleId { get; set; }
        [Required]

        public List<int>? Permissions { get; set; }
    }
}
