using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AttributeContracts
{
    public interface IAttributeModifyService
    {
        public Task<AttributeValue> ModifyAttributeValueStatus(int status, int id);
    }
}
