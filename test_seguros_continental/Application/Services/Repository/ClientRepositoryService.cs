using Microsoft.EntityFrameworkCore;
using test_seguros_continental.Infraestructure.Data;
using test_seguros_continental.Domain.Entities.Client;

namespace test_seguros_continental.Application.Services.Repository
{
    public class ClientRepositoryService
    {
        private ContinentalContext _continentalContext;
        private DbSet<ClientEntity> _dbSet;
        public ClientRepositoryService(ContinentalContext continentalContext)
        {
            _continentalContext = continentalContext;
            _dbSet = continentalContext.Set<ClientEntity>();
        }
        public async Task<IEnumerable<ClientEntity>> GetAllInclude(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            return await _dbSet.Include(a=>a.TypeClientEntity).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
