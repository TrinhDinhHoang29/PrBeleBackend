using PrBeleBackend.Core.Domain.Entities;
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
        public Task<List<AttributeTypeResponse>> GetAttributeType();

        public Task<decimal> GetAttributeValueCount();

        public Task<List<AttributeValueResponse>> GetFilteredAttributeValue(string? searchBy = "", string? searchStr = "");

        public Task<AttributeValueResponse> GetDetailAttributeValue(int id);
    }
}
