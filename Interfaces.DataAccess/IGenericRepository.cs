
namespace Interfaces.DataAccess
{
    public interface IGenericRepository<T> : IReadRepository<T>, IWriteRepository<T>
    {
    }
}
