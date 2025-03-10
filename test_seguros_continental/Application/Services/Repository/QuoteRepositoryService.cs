using Microsoft.EntityFrameworkCore;
using test_seguros_continental.Domain.Entities.Quote;
using test_seguros_continental.Infraestructure.Data;

namespace test_seguros_continental.Application.Services.Repository
{
    public class QuoteRepositoryService
    {
        private ContinentalContext _continentalContext;
        private DbSet<QuoteEntity> _dbSet;
        public QuoteRepositoryService(ContinentalContext continentalContext)
        {
            _continentalContext = continentalContext;
            _dbSet = _continentalContext.Set<QuoteEntity>();

        }

        public async Task<IEnumerable<QuoteEntity>> GetAllInclude(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            return await _dbSet.Include(a => a.CurrencyEntity).Include(b => b.ClientEntity).Include(c=>c.TypeInsuranceEntity).Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderByDescending(d => d.CreateAt).ToListAsync();
        }
    }
}
