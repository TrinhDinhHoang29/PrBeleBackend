﻿using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
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

        public async Task<decimal> GetAttributeValueCount()
        {
            return await this._attributeRepository.GetAttributeValueCount();
        }

        public async Task<List<AttributeValueResponse>> GetFilteredAttributeValue(string? searchBy = "", string? searchStr = "", int? status = 1)
        {
            switch (searchBy)
            {
                case nameof(AttributeValue.Name):
                    List<AttributeValueResponse> attributeValueByName = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => attributeValue.Name.Contains(searchStr), status);

                    return attributeValueByName;

                case nameof(AttributeValue.Value):
                    List<AttributeValueResponse> attributeValueByValue = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => attributeValue.Value.Contains(searchStr), status);

                    return attributeValueByValue;

                case nameof(AttributeValue.AttributeTypeId):
                    List<AttributeValueResponse> attributeValueByAttTypId = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => attributeValue.AttributeTypeId == Convert.ToInt32(searchStr), status);

                    return attributeValueByAttTypId;

                default:
                    List<AttributeValueResponse> attributeValue = await this._attributeRepository.GetFilteredAttributeValue(attributeValue => true, status);

                    return attributeValue;
            }
        }
    }
}
