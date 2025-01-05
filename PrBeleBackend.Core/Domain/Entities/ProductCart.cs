using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class ProductCart
    {
        public int CartId { get; set; }

        public int VariantId { get; set; }

        public int Quantity { get; set; }

        public Cart Cart { get; set; }

        public Variant Variant { get; set; }
    }
}
