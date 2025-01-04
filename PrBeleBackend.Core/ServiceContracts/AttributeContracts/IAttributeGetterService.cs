using PrBeleBackend.Core.DTO.AttributeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AttributeContracts
{
    public interface IAttributeGetterService
    {
        public Task<List<AttributeValueResponse>> GetFilteredAttributValue(AttributeValueGetterRequest req);
    }
}
