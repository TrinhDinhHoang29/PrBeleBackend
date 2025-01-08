using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.VariantDTOs
{
    public class VariantGetterRequest
    {
        [DefaultValue(1)]
        public int Page { get; set; }

        [DefaultValue(4)]
        public int Limit { get; set; }

        public string? SearchBy { get; set; }

        public string? SearchStr { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
