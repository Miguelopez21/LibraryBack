
using System.Threading.Tasks;

namespace Interfaces.DataAccess
{
    public interface IWriteRepository<T>
    {
        Task AddAsync(T entity);
    }
}
