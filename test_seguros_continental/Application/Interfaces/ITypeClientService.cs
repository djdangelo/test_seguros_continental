using test_seguros_continental.WebApi.DTOs.TypeClient;

namespace test_seguros_continental.Application.Interfaces
{
    public interface ITypeClientService
    {
        Task<IEnumerable<TypeClientDto>> GetAll();
        Task<TypeClientDto> Create(TypeClientDto typeClientDto);
        Task<TypeClientDto> Update(int id, TypeClientDto typeClientDto);
        Task<TypeClientDto> Delete(int id);
    }
}
