using Microsoft.AspNetCore.Identity;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.DiscountServices
{
    public class DiscountAdderServices : IDiscountAdderService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountAdderServices(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<DiscountResponse> AddDiscount(DiscountAddRequest discountAddRequest)
        {
            ValidationHelper.ModelValidation(discountAddRequest);
            if(discountAddRequest.ExpireDate < DateTime.Now)
            {
                throw new ArgumentException("ExpireDate is error !");
            }
            Discount discount = discountAddRequest.ToDiscount();
            discount.CreatedAt = DateTime.Now;
            discount.UpdatedAt = DateTime.Now;

            Discount result = await _discountRepository.AddDiscount(discount);

            return result.ToDiscountResponse();
        }
    }
}
