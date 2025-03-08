using Microsoft.AspNetCore.Mvc;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.WebApi.DTOs.Client;

namespace test_seguros_continental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClientService _clientService;
        public ClientController(
                IClientService clientService
        )
        {
            _clientService = clientService;
        }

        [HttpGet("data")]
        public async Task<IEnumerable<ClientDto>> GetAllPagination(int pageNumber, int pagerSize) => await _clientService.GetAllPagination(pageNumber, pagerSize);

        [HttpPost]
        public async Task<ActionResult<ClientDto>> Create(ClientDto clientDto)
        {
            try
            {
                var data = await _clientService.Create(clientDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ClientDto>> Update(int id, ClientDto clientDto)
        {
            try
            {
                var data = await _clientService.Update(id, clientDto);
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
            var data = await _clientService.Delete(id);
            return data == null ? NotFound() : Ok(data);
        }
    }
}
