using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Role
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        public List<RolePermission>? RolePermissions { get; set; }

        public List<Account>? Accounts { get; set; }


    }
}
