using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.DiscountDTOs
{
    public class DiscountResponse
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int DiscountValue { get; set; }

        public DateTime ExpireDate { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public static class DiscountResponseExtension
    {
        public static DiscountResponse ToDiscountResponse(this Discount discount)
        {
            return new DiscountResponse { 
                Id = discount.Id,
                Name = discount.Name,
                DiscountValue = discount.DiscountValue,
                Status = discount.Status,
                CreatedAt = discount.CreatedAt,
                UpdatedAt = discount.UpdatedAt
            };
        }
    }
}
