using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.ContactServices
{
    public class ContactSorterService : IContactSorterService
    {
        public async Task<List<ContactResponse>> SortCustomers(List<ContactResponse> contactResponse, string? sort, string? order)
        {
            if (sort == string.Empty)
            {
                return contactResponse;
            }
            switch (sort)
            {
                case nameof(Contact.FullName):
                    if (order == SortOrderOptions.ASC.ToString())
                        return contactResponse.OrderBy(a => a.FullName).ToList();
                    else
                        return contactResponse.OrderByDescending(a => a.FullName).ToList();
                case nameof(Contact.CreatedAt):
                    if (order == SortOrderOptions.ASC.ToString())
                        return contactResponse.OrderBy(a => a.CreatedAt).ToList();
                    else
                        return contactResponse.OrderByDescending(a => a.CreatedAt).ToList();
                default:
                    return contactResponse;
            }
        }
    }
}
