using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.AttributeDTOs
{
    public class AttributeValueAdderRequest
    {
        [Required]
        public int AttributeTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string Value { get; set; }   
    }
}
