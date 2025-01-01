using PrBeleBackend.Core.Domain.Entities;
using System;
namespace PrBeleBackend.Core.DTO.CustomerDTOs
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Sex { get; set; } // 0: Female, 1: Male, 2: Other
        public DateTime? Birthday { get; set; }
        public int TotalSpending { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public static class CustomerResponseExtension
    {
        public static CustomerResponse ToCustomerResponse(this Customer customer)
        {
            return new CustomerResponse
            {
                Id = customer.Id,
                FullName = customer.FullName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Sex = customer.Sex,
                Birthday = customer.Birthday,
                TotalSpending = customer.TotalSpending,
                Status = customer.Status,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };
        }
    }
}
