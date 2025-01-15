using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.CartDTOs
{
    public class CartUpdateRequest
    {
        [Required]
        public int VariantId {  get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
