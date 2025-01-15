using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.ProductServices
{
    public class ProductSearcherService : IProductSearcherService
    {
        private readonly IProductRepository? _productRepository;

        public ProductSearcherService(IProductRepository? productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<List<Product>> SearchProduct(string searchName, int page = 1, int limit = 10)
        {
            string keywordsStr = RemoveDiacritics.Handle(searchName.ToLower());

            List<string> keywords = keywordsStr.Split(' ').ToList();

            List<string> keywordsType2 = new List<string>();

            for(int i = 0; i < keywords.Count - 1; i++)
            {
                keywordsType2.Add(keywords[i] + keywords[i + 1]);
            }

            keywords.AddRange(keywordsType2);

            List<Product> keywordEle = await this._productRepository.SearchKeyword(keywords, page, limit);

            return keywordEle;
        }
    }
}
