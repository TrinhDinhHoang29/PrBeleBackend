using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.VariantContracts
{
    public interface IVariantSorterService
    {
        public Task<IEnumerable<VariantResponse>> SortVariant(IEnumerable<VariantResponse> variants, string? sort = "", SortOrderOptions? order = SortOrderOptions.ASC);
    }
}
