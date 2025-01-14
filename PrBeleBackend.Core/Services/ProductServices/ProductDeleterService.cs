﻿using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.ServiceContracts.ProductContracts;

namespace PrBeleBackend.Core.Services.ProductServices
{
    public class ProductDeleterService : IProductDeleterService
    {
        private readonly IProductRepository _productRepository;

        public ProductDeleterService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return await this._productRepository.DeleteProduct(id);
        }
    }
}
