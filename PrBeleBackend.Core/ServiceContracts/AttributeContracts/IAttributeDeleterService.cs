using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AttributeContracts
{
    public interface IAttributeDeleterService
    {
        public Task<AttributeValue> DeleteAtributeValue(int id);
    }
}
