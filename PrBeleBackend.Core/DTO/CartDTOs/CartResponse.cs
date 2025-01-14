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


        public decimal TotalMoney { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } // Tên sản phẩm
        public string Thumbnail { get; set; }
        public dynamic Attributes { get; set; } // Danh sách thuộc tính sản phẩm (nếu có)
        public int Quantity { get; set; } // Số lượng sản phẩm
        public decimal ProductPrice { get; set; }
        public decimal Discount { get; set; } // Mức giảm giá
    }
    public class AttributeDetail
    {
        public string AttributeType { get; set; } // Loại thuộc tính (VD: Màu sắc, kích thước)
        public string AttributeValue { get; set; } // Giá trị thuộc tính (VD: Đỏ, XL)
    }
    public static class CartResponseExtension
    {
        public static CartResponse ToCartResponse(this Cart cart)
        {
            return new CartResponse()
            {
                TotalMoney = cart.TotalMoney,
                CartItems = cart?.ProductCarts.Select(item => new CartItem
                {
                    ProductId = item.Variant.ProductId,
                    ProductName = item.Variant?.Product?.Name,
                    Thumbnail = item.Variant?.Thumbnail,
                    ProductPrice = item.Variant.Price,
                    Attributes = item.Variant?.VariantAttributeValues?.Select(e => new Dictionary<string, string>
                {
                    { e.AttributeValue.AttributeType.Name, e.AttributeValue.Name}
                    }),
                    Quantity = item.Quantity,
                    Discount = item.Variant?.Product?.Discount?.ExpireDate > DateTime.Now
               ? item.Variant.Product.Discount.DiscountValue
               : 0
                }).ToList()
            };
        }

    }
}
