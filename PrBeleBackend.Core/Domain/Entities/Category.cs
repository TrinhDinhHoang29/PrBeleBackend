using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? ReferenceCategoryId { get; set; }
        [Required]
        public int Status { get; set; }

        [Required]
        public string? Slug { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
