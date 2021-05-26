using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Interfaces.DataAccess;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private readonly IReadRepository<T> readRepository;
        private readonly IWriteRepository<T> writeRepository;

        public GenericRepository(IReadRepository<T> readRepository, IWriteRepository<T> writeRepository) 
        {
            this.readRepository = readRepository; 
            this.writeRepository = writeRepository;
        }

        public Task AddAsync(T entity)
        {
            return writeRepository.AddAsync(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null)
        {
            return readRepository.GetAllAsync(filter, includes);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> filter = null, List<string> includes = null)
        {
            return readRepository.GetAsync(filter, includes);
        }
    }
}
