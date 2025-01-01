﻿using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ProductContracts
{
    public interface IProductUpdaterService
    {
        public Task<Product> UpdateProduct(ProductUpdateRequest req, int id);
    }
}
