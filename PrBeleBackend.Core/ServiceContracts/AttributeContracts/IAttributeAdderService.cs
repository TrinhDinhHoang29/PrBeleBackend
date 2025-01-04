using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.AttributeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AttributeContracts
{
    public interface IAttributeAdderService
    {
        public Task<AttributeValue> AddAttributeValue(AttributeValueAdderRequest req);
    }
}
