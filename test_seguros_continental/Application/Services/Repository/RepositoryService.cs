using Microsoft.EntityFrameworkCore;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Infraestructure.Data;

namespace test_seguros_continental.Application.Services.Repository
{
    public class RepositoryService<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ContinentalContext _continentalContext;
        private DbSet<TEntity> _dbSet;
        public RepositoryService(ContinentalContext continentalContext)
        {
            _continentalContext = continentalContext;
            _dbSet = continentalContext.Set<TEntity>();
        }
        public async Task Add(TEntity entity) => await _dbSet.AddAsync(entity);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllPagination(int pageNumber = 1, int pageSize = 10) {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            return await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _dbSet.ToListAsync();

        public async Task<TEntity> GetById(int id) => await _dbSet.FindAsync(id);

        public async Task Save() => await _continentalContext.SaveChangesAsync();

        public IEnumerable<TEntity> Search(Func<TEntity, bool> predicate) => _dbSet.Where(predicate).ToList();

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}
