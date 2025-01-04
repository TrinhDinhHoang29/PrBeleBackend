using PrBeleBackend.Core.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Helpers
{
    public class PaginationHelper
    {
        public static async Task<PaginationResponse> Handle(int skip, int limit, int totalCount)
        {
            if (totalCount <= 0)
            {
                throw new ArgumentException("Total count must major 0");
            }

            if(limit <= 0)
            {
                throw new ArgumentException("Page size must major 0");
            }

            if (skip <= 0)
            {
                throw new ArgumentException("Page index must major 0");
            }

            int totalPage = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / limit));

            if(skip > totalPage)
            {
                skip = totalPage;
            }

            return new PaginationResponse
            {
                PageIndex = skip,
                PageSize = limit,
                PageCount = totalPage,
                TotalCount = totalCount
            };
        }
    }
}
