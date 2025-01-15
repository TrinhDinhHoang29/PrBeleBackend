using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Domain.Entities;

namespace PrBeleBackend.Core.DTO.ProductDTOs
{
    public class ProductSearchResponse
    {
        public ProductResponse? product { get; set; }

        public int matchCount { get; set; }
    }
}
