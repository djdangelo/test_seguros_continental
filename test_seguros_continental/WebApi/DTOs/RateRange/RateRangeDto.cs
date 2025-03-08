using System.ComponentModel.DataAnnotations;

namespace test_seguros_continental.WebApi.DTOs.RateRange
{
    public class RateRangeDto
    {
        public int? RateRangeId { get; set; }
        public double MountMin { get; set; }
        public int MountMax { get; set; }
        public double Rate { get; set; }
        public bool? Status { get; set; }
    }
}
