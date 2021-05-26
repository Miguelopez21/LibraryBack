using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Interfaces.DataAccess
{
    public interface IReadRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null);
    }
}
