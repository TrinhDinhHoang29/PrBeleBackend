using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.VariantDTOs;

namespace PrBeleBackend.Core.DTO.OrderDTOs
{
    public class OrderResponse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required, StringLength(64)]
        public string? FullName { get; set; }
        [Required, Phone, StringLength(16)]
        public string? PhoneNumber { get; set; }
        public string? Note { get; set; }
        public string? Email { get; set; }

        [Required, StringLength(255)]
        public string? Address { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalMoney { get; set; }
        [StringLength(32)]
        public string? PayMethod { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // Giá sản phẩm (sau giảm giá)
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<ProductOrder?>? ProductOrders { get; set; }
    }
    public static class OrderResponseExtension
    {
        public static OrderResponse ToOrderResponse(this Order order)
        {
            return new OrderResponse { 
                Id = order.Id,
                UserId = order.UserId,
                Email = order.Customer.Email,
                FullName = order.FullName,
                PhoneNumber = order.PhoneNumber,
                Address = order.Address,
                TotalMoney = order.TotalMoney,
                PayMethod = order.PayMethod,
                Note = order.Note,
                ShipDate = order.ShipDate,
                ReceiveDate = order.ReceiveDate,
                Status = order.Status,
                ProductOrders = order.ProductOrders,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt 
            };
        }
    }
}
