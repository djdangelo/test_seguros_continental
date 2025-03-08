using System.ComponentModel.DataAnnotations;

namespace test_seguros_continental.WebApi.DTOs.TypeInsurance
{
    public class TypeInsuranceDto
    {
        public int TypeInsuranceId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
