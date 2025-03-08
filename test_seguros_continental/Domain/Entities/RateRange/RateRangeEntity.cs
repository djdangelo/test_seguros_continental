using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test_seguros_continental.Domain.Entities.RateRange
{
    public class RateRangeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RateRangeId { get; set; }
        [Required, MinLength(1)]
        public double MountMin { get; set; }
        [Required, MinLength(1)]
        public int MountMax { get; set; }
        [Required, MinLength(1)]
        public double Rate { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
