using test_seguros_continental.Domain.Entities.Client;
using test_seguros_continental.Domain.Entities.Currency;
using test_seguros_continental.Domain.Entities.TypeInsurance;

namespace test_seguros_continental.WebApi.DTOs.Quote
{
    public class QuoteDTO
    {
        public int? QuoteId { get; set; }
        public int ClientId { get; set; }
        public int CurrencyId { get; set; }
        public int TypeInsuranceId { get; set; }
        public string DescriptionAsset { get; set; }
        public double TotalInsurance { get; set; }
        public double? DownPayment { get; set; }
        public double? Rate { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now.ToUniversalTime();
        public bool Status { get; set; }
        public CurrencyEntity? CurrencyEntity { get; set; }
        public ClientEntity? ClientEntity { get; set; }
        public TypeInsuranceEntity? TypeInsuranceEntity { get; set; }
    }
}
