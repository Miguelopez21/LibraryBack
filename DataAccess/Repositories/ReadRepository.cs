using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly DbSet<T> entities;

        public ReadRepository(IContext context)
        {
            entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null)
        {
            IQueryable<T> query = Filter(filter, includes);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null)
        {
            IQueryable<T> query = Filter(filter, includes);

            return await query.FirstOrDefaultAsync();
        }

        private IQueryable<T> Filter(Expression<Func<T, bool>> filter, List<string> includes)
        {
            IQueryable<T> query = entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (string include in includes ?? new List<string>())
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
