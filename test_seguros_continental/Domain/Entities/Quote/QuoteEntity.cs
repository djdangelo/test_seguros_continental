using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using test_seguros_continental.Domain.Entities.Client;
using test_seguros_continental.Domain.Entities.Currency;

namespace test_seguros_continental.Domain.Entities.Quote
{
    public class QuoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuoteId { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required, StringLength(500)]
        public string DescriptionAsset { get; set; }
        [Required, MinLength(1)]
        public double TotalInsurance { get; set; }
        [Required, MinLength(1)]
        public double DownPayment { get; set; }
        [Required, MinLength(1)]
        public double Rate { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        [Required]
        public bool Status { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual ClientEntity ClientEntity { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public virtual CurrencyEntity CurrencyEntity { get; set; }
    }
}
