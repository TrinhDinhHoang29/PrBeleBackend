using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.ProductDTOs
{
    public class ProductGetterRequest
    {
        [DefaultValue(1)]
        public int Skip { get; set; }

        [DefaultValue(4)]
        public int Limit { get; set; }

        public string? SearchBy { get; set; }

        public string? SearchStr { get; set; }
    }
}
