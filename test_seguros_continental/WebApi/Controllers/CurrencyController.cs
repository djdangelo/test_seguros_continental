using Microsoft.AspNetCore.Mvc;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.WebApi.DTOs.Currency;

namespace test_seguros_continental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        ICurrencyService _currencyService;
        public CurrencyController(
            ICurrencyService currencyService
            )
        {
            _currencyService = currencyService;
        }
        [HttpGet]
        public async Task<IEnumerable<CurrencyDto>> GetAll() => await _currencyService.GetAll();

        [HttpPost]
        public async Task<ActionResult<CurrencyDto>> Create(CurrencyDto currencyDto)
        {
            try
            {
                var data = await _currencyService.Create(currencyDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CurrencyDto>> Update(int id, CurrencyDto currencyDto)
        {
            try
            {
                var data = await _currencyService.Update(id, currencyDto);
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
            var data = await _currencyService.Delete(id);
            return data == null ? NotFound() : Ok(data);
        }
    }
}
