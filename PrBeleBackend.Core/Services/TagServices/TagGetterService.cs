using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.TagServices
{
    public class TagGetterService
    {
        private readonly ITagRepository _tagRepository;

        public TagGetterService(ITagRepository tagRepository)
        {
            this._tagRepository = tagRepository;
        }

        //public async Task<List<ProductResponse>> GetProductByTagId
    }
}
