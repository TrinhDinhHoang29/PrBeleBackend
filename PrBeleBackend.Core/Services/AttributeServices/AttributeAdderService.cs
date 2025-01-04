using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.DTO.AttributeDTOs;
using PrBeleBackend.Core.Helpers;

namespace PrBeleBackend.Core.Services.AttributeServices
{
    public class AttributeAdderService : IAttributeAdderService
    {
        private readonly IAttributeRepository? _attributeRepository;

        public AttributeAdderService(IAttributeRepository attributeGetterService)
        {
            _attributeRepository = attributeGetterService;
        }

        public async Task<AttributeValue> AddAttributeValue(AttributeValueAdderRequest req)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            AttributeValue attributeValue = req.ToAttributeValue();

            attributeValue.CreatedAt = DateTime.Now;
            attributeValue.UpdatedAt = DateTime.Now;

            return await this._attributeRepository.AddAttributeValue(attributeValue);
        }
    }
}
