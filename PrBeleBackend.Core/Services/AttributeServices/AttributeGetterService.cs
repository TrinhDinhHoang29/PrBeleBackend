using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using PrBeleBackend.Core.DTO.AttributeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Domain.RepositoryContracts;

namespace PrBeleBackend.Core.Services.AttributeServices
{
    public class AttributeGetterService : IAttributeGetterService
    {
        private readonly IAttributeRepository? _attributeRepository;

        public AttributeGetterService(IAttributeRepository attributeGetterService)
        {
            _attributeRepository = attributeGetterService;
        }

        public async Task<List<AttributeValueResponse>> GetAttributeValue(int typeId)
        {
            return await this._attributeRepository.GetAttributeValue(typeId);
        }

        public async Task<List<AttributeTypeResponse>> GetAttributeType()
        {
            return await this._attributeRepository.GetAttributeType();
        }

        public async Task<decimal> GetAttributeValueCount()
        {
            return await this._attributeRepository.GetAttributeValueCount();
        }

        public async Task<List<AttributeValueResponse>> GetFilteredAttributeValue(string? searchBy = "", string? searchStr = "")
        {
            if(searchStr == null || searchBy == null)
            {
                List<AttributeValueResponse> attributeValue = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => true);

                return attributeValue;
            }

            switch (searchBy)
            {
                case nameof(AttributeValue.Name):
                    List<AttributeValueResponse> attributeValueByName = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => attributeValue.Name.Contains(searchStr));

                    return attributeValueByName;

                case nameof(AttributeValue.Value):
                    List<AttributeValueResponse> attributeValueByValue = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => attributeValue.Value.Contains(searchStr));

                    return attributeValueByValue;

                case nameof(AttributeValue.AttributeTypeId):
                    List<AttributeValueResponse> attributeValueByAttTypId = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => attributeValue.AttributeTypeId == Convert.ToInt32(searchStr));

                    return attributeValueByAttTypId;
                default:
                    {
                        List<AttributeValueResponse> attributeValue = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => true);

                        return attributeValue;
                    }
            }
        }

        public async Task<AttributeValueResponse> GetDetailAttributeValue(int id)
        {
            return await this._attributeRepository.GetDetailAttributeValue(id);
        }
    }
}
