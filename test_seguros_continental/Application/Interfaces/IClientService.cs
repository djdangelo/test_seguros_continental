using test_seguros_continental.WebApi.DTOs.Client;

namespace test_seguros_continental.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllPagination(int pageNumber, int pageSize);
        Task<ClientDto> GetById(int id);
        Task<ClientDto> Create(ClientDto clientDto);
        Task<ClientDto> Update(int id, ClientDto clientDto);
        Task<ClientDto> Delete(int id);
    }
}
