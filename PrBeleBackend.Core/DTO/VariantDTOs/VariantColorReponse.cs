using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.VariantDTOs
{
    public class VariantColorReponse
    {
        public int VariantId { get; set; }

        public string Color { get; set; }

        public string Thumbnail { get; set; }

        public int ColorId { get; set; }
    }
}
