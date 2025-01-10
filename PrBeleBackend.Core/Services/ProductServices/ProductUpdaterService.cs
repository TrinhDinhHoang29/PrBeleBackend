using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts;
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
    public class ProductUpdaterService : IProductUpdaterService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICloudinaryContract _cloudinaryService;

        public ProductUpdaterService(IProductRepository productRepository, ICloudinaryContract cloudinaryService)
        {
            this._productRepository = productRepository;
            this._cloudinaryService = cloudinaryService;
        }

        public async Task<Product> UpdateProduct(ProductUpdateRequest req, int id)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            Product productUpdate = req.ToProduct();

            productUpdate.Slug = ConvertToSlugHelper.ConvertToUnaccentedSlug(req.Name);
            productUpdate.UpdatedAt = DateTime.Now;
            
            if(req.ProductFile != null)
            {
                productUpdate.Thumbnail = await this._cloudinaryService.UploadImageAsync(req.ProductFile, "product", 300, 400);
            }

            return await this._productRepository.UpdateProduct(productUpdate, id);
        }
    }
}
