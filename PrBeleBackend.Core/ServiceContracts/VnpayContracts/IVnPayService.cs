using Microsoft.AspNetCore.Http;
using PaymentProject.Models;
using PrBeleBackend.Core.DTO.OrderDTOs;

namespace PaymentProject.VNPay
{
    public interface IVnPayService
    {
        public string CreatePaymentUrl(PaymentInformationModel model, HttpContext context, int UserId,string FullName
            ,string PhoneNumber,
            string Address,
            string Note);
        public PaymentResponseModel PaymentExecute(IQueryCollection collections);

    }
}
