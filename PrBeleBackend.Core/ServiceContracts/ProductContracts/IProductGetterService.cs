﻿using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ProductContracts
{
    public interface IProductGetterService
    {
        public Task<List<Product>> GetProductsWithCondition(int? id, string? slug);

        public Task<List<ProductResponse>> SelectProductForClient(List<Product> products);

        public Task<List<ProductResponse>> SelectProductForAdmin(List<Product> products);

        public Task<List<ProductResponse>> GetFilteredProduct(List<ProductResponse> products, string? searchBy, string? searchStr);
    }
}
