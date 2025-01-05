using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required,StringLength(64)]
        public string? FullName { get; set; }
        [Required, Phone,StringLength(16)]
        public string? PhoneNumber { get; set; }
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
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
        public Customer Customer { get; set; }
    }
}
