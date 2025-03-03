﻿using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.Pagination;
using PrBeleBackend.Core.DTO.VariantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IVariantRepository
    {
        public Task<int> GetVariantCountByProductId(int productId);

        public Task<List<VariantSizeResponse>> GetVariantByProductIdAndColor(int productId, int colorId);

        public Task<List<VariantResponse>> GetFilteredVariant(Expression<Func<Variant, bool>> predicate, int productId);

        public Task<VariantResponse> GetVariantDetail(int id);

        public Task<Variant> CreateVariant(Variant variant);

        public Task<Variant> UpdateVariant(Variant variant, int id);

        public Task<Variant> ModifyVariant(VariantModifierRequest req, int id);

        public Task<Variant> DeleteVariant(int id);
    }
}
