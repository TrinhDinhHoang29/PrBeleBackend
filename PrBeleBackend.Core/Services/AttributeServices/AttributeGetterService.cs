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

        public async Task<List<AttributeValueResponse>> GetFilteredAttributValue(AttributeValueGetterRequest req)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            PaginationResponse paginationResponse = await PaginationHelper.Handle(req.Skip, req.Limit, await this._attributeRepository.GetAttributeValueCount());

            switch (req.SearchBy)
            {
                case nameof(AttributeValue.Name):
                    List<AttributeValueResponse> attributeValueByName = await this._attributeRepository.GetFilteredAttributeValue(paginationResponse, attributeValue => attributeValue.Name.Contains(req.SearchStr));

                    return attributeValueByName;

                case nameof(AttributeValue.Value):
                    List<AttributeValueResponse> attributeValueByValue = await this._attributeRepository.GetFilteredAttributeValue(paginationResponse, attributeValue => attributeValue.Value.Contains(req.SearchStr));

                    return attributeValueByValue;

                default:
                    List<AttributeValueResponse> attributeValue = await this._attributeRepository.GetFilteredAttributeValue(paginationResponse, attributeValue => true);

                    return attributeValue;
            }
        }
    }
}
