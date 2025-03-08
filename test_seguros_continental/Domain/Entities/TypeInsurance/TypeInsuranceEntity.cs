using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test_seguros_continental.Domain.Entities.TypeInsurance
{
    public class TypeInsuranceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeInsuranceId { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }

    }
}
