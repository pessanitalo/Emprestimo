using System.Linq.Expressions;


namespace CredEmprestimo.Data.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (condition)
            {
                query = query.Where(predicate);
            }
            return query;
        }
    }
}
