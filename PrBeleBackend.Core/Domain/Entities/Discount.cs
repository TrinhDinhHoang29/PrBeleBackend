using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; } 

        public int DiscountValue {  get; set; }

        public DateTime ExpireDate { get; set; }
        
        public int Status { get; set; }
        
        public bool Deleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Product> products { get; set; }
    }
    public static class DiscountExtension
    {
        public static Discount ToDiscount(this DiscountAddRequest discountAddRequest)
        {
            return new Discount()
            {
                Name = discountAddRequest.Name,
                DiscountValue = discountAddRequest.DiscountValue,
                ExpireDate = discountAddRequest.ExpireDate,
                Status = discountAddRequest.Status,
            };
        }
        public static Discount ToDiscount(this DiscountUpdateRequest discountUpdateRequest)
        {
            return new Discount()
            {
                Name = discountUpdateRequest.Name,
                DiscountValue = discountUpdateRequest.DiscountValue,
                ExpireDate = discountUpdateRequest.ExpireDate,
                Status = discountUpdateRequest.Status,
            };
        }
    }
}
