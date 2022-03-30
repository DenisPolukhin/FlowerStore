using FlowStoreBackend.Common.Pagination;
using Microsoft.EntityFrameworkCore;

namespace FlowStoreBackend.Common.Helpers
{
    public static class QueryablePaginatedListHelper
    {
        public static async Task<IPaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentException("Page index start from 1");
            }

            var totalCount = await source.CountAsync();
            var data = await source.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (decimal)pageSize),
                Data = data
            };
        }
    }
}
