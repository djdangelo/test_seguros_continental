using Microsoft.EntityFrameworkCore;
using test_seguros_continental.Domain.Entities.Client;
using test_seguros_continental.Domain.Entities.Currency;
using test_seguros_continental.Domain.Entities.Quote;
using test_seguros_continental.Domain.Entities.RateRange;
using test_seguros_continental.Domain.Entities.TypeClient;
using test_seguros_continental.Domain.Entities.TypeInsurance;

namespace test_seguros_continental.Infraestructure.Data
{
    public class ContinentalContext : DbContext
    {
        public ContinentalContext(DbContextOptions<ContinentalContext> options) : base(options) { }
        public DbSet<TypeClientEntity> TypeClient { get; set; }
        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<CurrencyEntity> Currency { get; set; }
        public DbSet<QuoteEntity> Quote { get; set; }
        public DbSet<TypeInsuranceEntity> TypeEnsurance { get; set; }
        public DbSet<RateRangeEntity> RateRange { get; set; }
    }
}
