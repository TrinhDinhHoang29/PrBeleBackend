﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.VariantDTOs
{
    public class VariantSizeResponse
    {
        public int VariantId { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
    }
}