using System.Threading.Tasks;
using Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly IContext context;
        private readonly DbSet<T> entities;

        public WriteRepository(IContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
