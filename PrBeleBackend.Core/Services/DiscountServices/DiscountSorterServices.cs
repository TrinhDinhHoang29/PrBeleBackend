using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.DiscountDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.DiscountContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.DiscountServices
{
    public class DiscountSorterServices : IDiscountSorterService
    {
        public async Task<List<DiscountResponse>> SortDiscounts(List<DiscountResponse> discountResponse, string? sort, string? order)
        {
            if (sort == string.Empty)
            {
                return discountResponse;
            }
            switch (sort)
            {
                case nameof(Discount.Name):
                    if (order == SortOrderOptions.ASC.ToString())
                        return discountResponse.OrderBy(a => a.Name).ToList();
                    else
                        return discountResponse.OrderByDescending(a => a.Name).ToList();
                case nameof(Discount.DiscountValue):
                    if (order == SortOrderOptions.ASC.ToString())
                        return discountResponse.OrderBy(a => a.DiscountValue).ToList();
                    else
                        return discountResponse.OrderByDescending(a => a.DiscountValue).ToList();
                case nameof(Discount.CreatedAt):
                    if (order == SortOrderOptions.ASC.ToString())
                        return discountResponse.OrderBy(a => a.CreatedAt).ToList();
                    else
                        return discountResponse.OrderByDescending(a => a.CreatedAt).ToList();
                default:
                    return discountResponse;
            }
        }
    }
}
