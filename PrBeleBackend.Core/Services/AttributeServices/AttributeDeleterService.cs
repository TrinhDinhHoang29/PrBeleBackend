using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.AttributeServices
{
    public class AttributeDeleterService : IAttributeDeleterService
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeDeleterService(IAttributeRepository attributeRepository)
        {
            this._attributeRepository = attributeRepository;
        }

        public async Task<AttributeValue> DeleteAtributeValue(int id)
        {
            return await this._attributeRepository.DeleteAttributeValue(id);
        }
    }
}
