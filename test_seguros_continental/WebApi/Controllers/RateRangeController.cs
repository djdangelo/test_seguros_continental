using Microsoft.AspNetCore.Mvc;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.WebApi.DTOs.RateRange;

namespace test_seguros_continental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateRangeController : ControllerBase
    {
        IRateRangeService _rateRangeService;
        public RateRangeController(IRateRangeService rateRangeService)
        {
            _rateRangeService = rateRangeService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<RateRangeDto>> GetAll() => await _rateRangeService.GetAll();
        
        [HttpPost]
        public async Task<ActionResult<RateRangeDto>> Create(RateRangeDto rateRangeDto)
        {
            try
            {
                var rateRange = await _rateRangeService.Create(rateRangeDto);
                return Ok(rateRange);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RateRangeDto>> Update(int id, RateRangeDto rateRangeDto)
        {
            try
            {
                var rateRange = await _rateRangeService.Update(id, rateRangeDto);
                return rateRange == null ? NotFound() : Ok(rateRange);
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
            var rateRange = await _rateRangeService.Delete(id);
            return rateRange == null ? NotFound() : Ok(rateRange);
        }

    }
}
