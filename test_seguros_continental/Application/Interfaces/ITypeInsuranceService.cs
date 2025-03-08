using test_seguros_continental.WebApi.DTOs.RateRange;
using test_seguros_continental.WebApi.DTOs.TypeInsurance;

namespace test_seguros_continental.Application.Interfaces
{
    public interface ITypeInsuranceService
    {
        Task<IEnumerable<TypeInsuranceDto>> GetAll();
        Task<TypeInsuranceDto> Create(TypeInsuranceDto typeInsuranceDto);
        Task<TypeInsuranceDto> Update(int id, TypeInsuranceDto typeInsuranceDto);
        Task<TypeInsuranceDto> Delete(int id);
    }
}
