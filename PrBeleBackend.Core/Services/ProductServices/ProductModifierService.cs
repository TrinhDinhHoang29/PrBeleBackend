using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Helpers;

namespace PrBeleBackend.Core.Services.ProductServices
{
    public class ProductModifierService : IProductModifierService
    {
        private readonly IProductRepository _productRepository;

        public ProductModifierService(IProductRepository productRepository) 
        { 
            this._productRepository = productRepository;
        }

        public async Task<Product> ModifyProduct(ProductModifyRequest req, int id)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            return await _productRepository.ModifyProduct(req, id);
        }
    }
}
