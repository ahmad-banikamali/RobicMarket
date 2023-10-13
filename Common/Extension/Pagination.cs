using System.Linq.Expressions;

namespace Common.Extension
{
    public static class Pagination
    {
        //used by LINQ to SQL
        public static IQueryable<TSource> ToPaged<TSource>(this IQueryable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }


        //--------used by LINQ--------
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount)
        {
            rowsCount = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

 
        public static IQueryable<T> PagedResult<T, TResult>(this IQueryable<T> query, int pageNum, int pageSize,
                Expression<Func<T, TResult>> orderByProperty, bool isAscendingOrder, out int rowsCount)
        {
            if (pageSize <= 0) pageSize = 20; 
            rowsCount = query.Count(); 
            if (/*rowsCount <= pageSize ||*/ pageNum <= 0) pageNum = 1; 
            int excludedRows = (pageNum - 1) * pageSize; 
            return query.Skip(excludedRows).Take(pageSize);
        }


        public static IQueryable<TSource> PagedResult<TSource>(this IQueryable<TSource> query, int pageNum, int pageSize)
        {
            if (pageSize <= 0) pageSize = 20;  
            if (pageNum <= 0) pageNum = 1; 
            var excludedRows = (pageNum - 1) * pageSize; 
            return query.Skip(excludedRows).Take(pageSize);
        }
    }
}
