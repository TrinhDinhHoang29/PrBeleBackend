﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [StringLength(64)]
        public string Name { get; set; }
        public List<ProductTag> productTags { get; set; }
    }
}
