using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Domain.RepositoryContracts;

namespace PrBeleBackend.Core.Services.AttributeServices
{
    public class AttributeModifyService : IAttributeModifyService
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeModifyService(IAttributeRepository attributeRepository)
        {
            this._attributeRepository = attributeRepository;
        }

        public async Task<AttributeValue> ModifyAttributeValueStatus(int status, int id)
        {
            if(status > 2 || status < 0)
            {
                throw new ArgumentException("Wrong status!");
            }

            return await this._attributeRepository.ModifyAttributeValueStatus(status, id);
        }
    }
}
