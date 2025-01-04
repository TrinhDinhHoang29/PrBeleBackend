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
    public class AttributeUpdaterService : IAttributeUpdaterService
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeUpdaterService(IAttributeRepository attributeRepository) 
        { 
            this._attributeRepository = attributeRepository;
        }

        public async Task<AttributeValue> UpdateAttributeValue(AttributeValueUpdaterRequest req, int id)
        {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            AttributeValue attributeValue = req.ToAttributeValue();

            return await this._attributeRepository.UpdateAttributeValue(attributeValue, id);
        }
    }
}
