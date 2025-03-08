using Microsoft.AspNetCore.Mvc;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.WebApi.DTOs.TypeClient;

namespace test_seguros_continental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeClientController : ControllerBase
    {
        ITypeClientService _typeClientService;
        public TypeClientController(
                ITypeClientService typeClientService
            )
        {
            _typeClientService = typeClientService;
        }
        [HttpGet]
        public async Task<IEnumerable<TypeClientDto>> GetAll() => await _typeClientService.GetAll();

        [HttpPost]
        public async Task<ActionResult<TypeClientDto>> Create(TypeClientDto typeClientDto)
        {
            try
            {
                var data = await _typeClientService.Create(typeClientDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeClientDto>> Update(int id, TypeClientDto typeClientDto)
        {
            try
            {
                var data = await _typeClientService.Update(id, typeClientDto);
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
            var data = await _typeClientService.Delete(id);
            return data == null ? NotFound() : Ok(data);
        }
    }
}
