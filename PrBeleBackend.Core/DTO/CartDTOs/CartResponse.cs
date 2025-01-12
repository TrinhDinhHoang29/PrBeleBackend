using PrBeleBackend.Core.Domain.Entities;
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

        public decimal TotalMoney { get; set; }
        public List<ProductCart> ProductCarts { get; set; }
    }
    public static class CartResponseExtension
    {
        public static CartResponse ToCartResponse(this Cart cart)
        {
            return new CartResponse()
            {
                TotalMoney = cart.TotalMoney,
                ProductCarts = cart.ProductCarts,
            };
        }
    }
}
