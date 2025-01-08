using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AttributeDTOs;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AttributeServices
{
    public class AttributeSorterService : IAttributeSorterService
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeSorterService(IAttributeRepository attributeRepository)
        {
            this._attributeRepository = attributeRepository;
        }

        public async Task<IEnumerable<AttributeValueResponse>> SortAttributeValue(IEnumerable<AttributeValueResponse> attributeValues, string? sort = "", SortOrderOptions? order = SortOrderOptions.ASC)
        {
            switch (sort)
            {
                case nameof(AttributeValueResponse.CreatedAt):
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return attributeValues.OrderBy(attVal => attVal.CreatedAt).ToList();
                        }
                        else
                        {
                            return attributeValues.OrderByDescending(attVal => attVal.CreatedAt).ToList();
                        }
                    }
                case nameof(AttributeValueResponse.Name):
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return attributeValues.OrderBy(attVal => attVal.Name).ToList();
                        }
                        else
                        {
                            return attributeValues.OrderByDescending(attVal => attVal.Name).ToList();
                        }
                    }
                case nameof(AttributeValueResponse.Value):
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return attributeValues.OrderBy(attVal => attVal.Name).ToList();
                        }
                        else
                        {
                            return attributeValues.OrderByDescending(attVal => attVal.Name).ToList();
                        }
                    }
                default:
                    {
                        if (order == SortOrderOptions.ASC)
                        {
                            return attributeValues.OrderBy(attVal => attVal.Id).ToList();
                        }
                        else
                        {
                            return attributeValues.OrderByDescending(attVal => attVal.Id).ToList();
                        }
                    }
            }
        }
    }
}
