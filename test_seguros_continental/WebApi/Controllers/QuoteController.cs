using Microsoft.AspNetCore.Mvc;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.WebApi.DTOs.Quote;

namespace test_seguros_continental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        IQuoteService _quoteService;
        public QuoteController(
                IQuoteService quoteService
            )
        {
            _quoteService = quoteService;
        }
        [HttpGet("data")]
        public async Task<IEnumerable<QuoteDTO>> GetAllPagination(int pageNumber, int pagerSize) => await _quoteService.GetAllPagination(pageNumber, pagerSize);

        [HttpPost]
        public async Task<ActionResult<QuoteDTO>> Create(QuoteDTO quoteDTO)
        {
            try
            {
                var data = await _quoteService.Create(quoteDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<QuoteDTO>> Update(int id, QuoteDTO quoteDTO)
        {
            try
            {
                var data = await _quoteService.Update(id, quoteDTO);
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
            var data = await _quoteService.Delete(id);
            return data == null ? NotFound() : Ok(data);
        }
    }
}
