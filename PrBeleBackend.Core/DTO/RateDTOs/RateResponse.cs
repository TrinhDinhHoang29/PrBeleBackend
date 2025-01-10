using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.RateDTOs
{
    public class RateResponse
    {
        public int Id { get; set; }
        public string? pImage { get; set; }
        public string? pName { get; set; }
        public string? Name { get; set; }
        public string? RName { get; set; }
        public int Star { get; set; }
        public string? Content { get; set; }
        public string? Reply { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public static class RateResponseExtension
    {
        public static RateResponse ToRateResponse(this Rate rate)
        {
            return new RateResponse
            {
                Id = rate.Id,
                pImage = rate.Product?.Thumbnail,
                pName = rate.Product?.Name,
                Name = rate.UserType == "Customer"? rate.Customer.FullName : rate.Account.FullName,
                RName = rate.RateReference?.Account?.FullName,
                Star = rate.Star,
                Content = rate.Content,
                Reply = rate.RateReference?.Content,
                Status = rate.Status,
                CreatedAt = rate.CreatedAt,
                UpdatedAt = rate.UpdatedAt,
            };
        }
    }
}
