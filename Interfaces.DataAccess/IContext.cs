using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Interfaces.DataAccess
{
    public interface IContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
