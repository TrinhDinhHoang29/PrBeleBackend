using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.DTO.TagDTOs;
using PrBeleBackend.Core.ServiceContracts.TagContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.TagServices
{
    public class TagGetterService : ITagGetterService
    {
        private readonly ITagRepository _tagRepository;

        public TagGetterService(ITagRepository tagRepository)
        {
            this._tagRepository = tagRepository;
        }

        public async Task<List<TagResponse>> GetAllTag()
        {
            return await this._tagRepository.GetAllTag();
        }
    }
}
