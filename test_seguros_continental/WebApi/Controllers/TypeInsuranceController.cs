
using Microsoft.AspNetCore.Mvc;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.WebApi.DTOs.TypeInsurance;

namespace test_seguros_continental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeInsuranceController : ControllerBase
    {
        ITypeInsuranceService _typeInsuranceService;
        public TypeInsuranceController(
            ITypeInsuranceService typeInsuranceService
        )
        {
            _typeInsuranceService = typeInsuranceService;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeInsuranceDto>> GetAll() => await _typeInsuranceService.GetAll();

        [HttpPost]
        public async Task<ActionResult<TypeInsuranceDto>> Create(TypeInsuranceDto typeInsuranceDto)
        {
            try
            {
                var data = await _typeInsuranceService.Create(typeInsuranceDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeInsuranceDto>> Update(int id, TypeInsuranceDto typeInsuranceDto)
        {
            try
            {
                var data = await _typeInsuranceService.Update(id, typeInsuranceDto);
                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _typeInsuranceService.Delete(id);
            return data == null ? NotFound() : Ok(data);
        }
    }
}
