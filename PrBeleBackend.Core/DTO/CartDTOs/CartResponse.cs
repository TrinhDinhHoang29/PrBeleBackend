using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.CartDTOs
{
    public class CartResponse
    {
        public decimal TotalPrice { get; set; }

        public decimal TotalDiscount { get; set; }

    }
}
