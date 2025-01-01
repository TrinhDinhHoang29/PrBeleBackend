using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.CustomerServices
{
    public class CustomerSorterService : ICustomerSorterService
    {
        public async Task<List<CustomerResponse>> SortCustomers(List<CustomerResponse> customerResponse, string? sort, string? order)
        {
            if (sort == string.Empty)
            {
                return customerResponse;
            }
            switch (sort)
            {
                case nameof(Customer.FullName):
                    if (order == SortOrderOptions.ASC.ToString())
                        return customerResponse.OrderBy(a => a.FullName).ToList();
                    else
                        return customerResponse.OrderByDescending(a => a.FullName).ToList();
                case nameof(Customer.CreatedAt):
                    if (order == SortOrderOptions.ASC.ToString())
                        return customerResponse.OrderBy(a => a.CreatedAt).ToList();
                    else
                        return customerResponse.OrderByDescending(a => a.CreatedAt).ToList();
                default:
                    return customerResponse;
            }
        }
    }
}
