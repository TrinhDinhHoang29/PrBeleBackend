using PrBeleBackend.Core.DTO.AttributeDTOs;
using PrBeleBackend.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AttributeContracts
{
    public interface IAttributeSorterService
    {
        public Task<IEnumerable<AttributeValueResponse>> SortAttributeValue(IEnumerable<AttributeValueResponse> attributeValues, string? sort = "", SortOrderOptions? order = SortOrderOptions.ASC);
    }
}
