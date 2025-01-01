using System.ComponentModel.DataAnnotations;


namespace PrBeleBackend.Core.Domain.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        public string? Code { get; set; }
        public List<RolePermission>? RolePermissions { get; set; }

    }
    
}
