using Microsoft.EntityFrameworkCore;
using pressAgency.Shared.DTO.Common;

namespace pressAgency.Domain.Repository.Extensions
{
    public static class QueryExtension
    {
        /// <summary>
        /// Extends IQueryable and returns paginated reposne
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>PagedResult<T></returns>
        public static async Task<PagedResult<T>> Paginate<T>(this IQueryable<T> query,
                                                             int page,
                                                             int pageSize)
        {
            int totalRecords = await query.CountAsync();

            if(totalRecords != 0)
            {
                int skipItems = (page - 1) * pageSize;

                var items = await query.Skip(skipItems)
                                       .Take(pageSize)
                                       .ToListAsync();

                return new PagedResult<T>
                {
                    Records = items,
                    Pagination = new()
                    {
                        TotalRecord = totalRecords,
                        PageSize = items.Count,
                        CurrentPage = page,
                        HasNext = page * pageSize < totalRecords,
                        HasPrevious = page > 1
                    }
                };
            }

            return new PagedResult<T>();
        }
    }
}
