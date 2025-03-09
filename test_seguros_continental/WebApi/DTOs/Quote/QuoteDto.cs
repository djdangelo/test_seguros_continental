
using test_seguros_continental.WebApi.DTOs.Client;
using test_seguros_continental.WebApi.DTOs.Currency;
using test_seguros_continental.WebApi.DTOs.TypeInsurance;

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
        public DateTime? CreateAt { get; set; }
        public bool Status { get; set; }
        public CurrencyDto? currencyDto { get; set; }
        public ClientDto? clientDto { get; set; }
        public TypeInsuranceDto? TypeInsuranceDto { get; set; }
    }
}
