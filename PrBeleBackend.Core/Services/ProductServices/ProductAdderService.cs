﻿using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.ProductDTOs;
using System.ComponentModel.DataAnnotations;
using PrBeleBackend.Core.Helpers;
using PrBeleBackend.Core.ServiceContracts;

namespace PrBeleBackend.Core.Services.ProductServices
{
    public class ProductAdderService : IProductAdderService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICloudinaryContract _cloudinaryService;

        public ProductAdderService(IProductRepository productRepository, ICloudinaryContract cloudinaryService)
        {
            this._productRepository = productRepository;
            this._cloudinaryService = cloudinaryService;
        }

        public async Task<Product> AddProduct(ProductAddRequest? req)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            ValidationHelper.ModelValidation(req);

            List<string> keywords = req.Keyword.Split(',').ToList();

            Product product = req.ToProduct();

            product.Slug = ConvertToSlugHelper.ConvertToUnaccentedSlug(product.Name);
            product.View = 0;
            product.Like = 0;
            product.UpdatedAt = DateTime.Now;
            product.CreatedAt = DateTime.Now;

            if(req.ProductFile != null)
            {
                product.Thumbnail = await this._cloudinaryService.UploadImageAsync(req.ProductFile, "product", 300, 400);
            }

            return await this._productRepository.AddProduct(product, keywords);
        }
    }
}
