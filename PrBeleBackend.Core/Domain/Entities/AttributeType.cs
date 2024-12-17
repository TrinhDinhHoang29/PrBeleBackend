using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class AttributeType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<AttributeValue>? AttributeValues { get; set; }
        public List<ProductAttributeType>? ProductAttributeTypes { get; set; }
    }
}
