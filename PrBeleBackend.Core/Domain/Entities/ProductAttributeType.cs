﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class ProductAttributeType
    {
        public int ProductId { get; set; }
        public int AttributeTypeId { get; set; }
        public Product? Product { get; set; }
        public AttributeType? AttributeType { get; set; }
    }
}
