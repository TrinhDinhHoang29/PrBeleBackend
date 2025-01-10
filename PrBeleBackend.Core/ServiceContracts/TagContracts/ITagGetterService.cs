using PrBeleBackend.Core.DTO.TagDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.TagContracts
{
    public interface ITagGetterService
    {
        public Task<List<TagResponse>> GetAllTag();
    }
}
