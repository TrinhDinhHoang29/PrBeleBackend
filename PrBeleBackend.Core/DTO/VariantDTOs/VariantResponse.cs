using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.VariantDTOs
{
    public class VariantResponse
    {
        [Key]
        public int Id { get; set; }

        public string? ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string? Thumbnail { get; set; }

        public int Status { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<AttributeValue>? AttributeValues { get; set; }

    }
}
