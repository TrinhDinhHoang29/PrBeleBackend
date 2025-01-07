using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.VariantDTOs
{
    public class VariantModifierRequest
    {
        [Required]
        public string ModifyField { get; set; }

        public string? ModifyValue { get; set; }

        public string? ModifyAction { get; set; }
    }
}
