
namespace test_seguros_continental.WebApi.DTOs.Quote
{
    public class QuoteDTO
    {
        public int? QuoteId { get; set; }
        public int ClientId { get; set; }
        public int CurrencyId { get; set; }
        public string DescriptionAsset { get; set; }
        public double TotalInsurance { get; set; }
        public double? DownPayment { get; set; }
        public double? Rate { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool Status { get; set; }
    }
}
