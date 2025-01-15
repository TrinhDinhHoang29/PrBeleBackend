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

        public async Task<bool> ModifyWishList(int customerId, int productId, string action)
        {
            if(action == "Add")
            {
                return await this._productRepository.AddProductToWishList(customerId, productId);
            }
            else if(action == "Remove")
            {
                return await this._productRepository.RemoveProductFromWishList(customerId, productId);
            }
            else
            {
                throw new ArgumentNullException("Wrong action name!");
            }
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
