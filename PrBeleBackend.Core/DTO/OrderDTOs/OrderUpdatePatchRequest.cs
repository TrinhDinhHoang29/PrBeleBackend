using System.ComponentModel.DataAnnotations;


namespace PrBeleBackend.Core.DTO.OrderDTOs
{
    public class OrderUpdatePatchRequest
    {
        [Required]
        [Range(-1, 4, ErrorMessage = "Status must be either 1 or 4.")]
        public int Status { get; set; }
    }
}
