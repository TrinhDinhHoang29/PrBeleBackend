using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class VariantAttributeValue
    {
        public int VariantId { get; set; }

        public int AttributeValueId { get; set; }


        public Variant? Variant { get; set; }

        public AttributeValue? AttributeValue { get; set; }
    }
}
