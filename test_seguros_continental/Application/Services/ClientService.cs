using AutoMapper;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Application.Services.Repository;
using test_seguros_continental.Domain.Entities.Client;
using test_seguros_continental.WebApi.DTOs.Client;

namespace test_seguros_continental.Application.Services
{
    public class ClientService : IClientService
    {
        IRepository<ClientEntity> _repository;
        ClientRepositoryService _clientRepositoryService;
        IMapper _mapper;
        public ClientService(
            IRepository<ClientEntity> repository,
            ClientRepositoryService clientRepositoryService,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _repository = repository;
            _clientRepositoryService = clientRepositoryService; 
        }
        public async Task<ClientDto> Create(ClientDto clientDto)
        {
            await _repository.Add(_mapper.Map<ClientEntity>(clientDto));
            await _repository.Save();
            return clientDto;
        }

        public async Task<ClientDto> Delete(int id)
        {
            var client = await _repository.GetById(id);
            if (client == null)
            {
                return null;
            }
            var data = _mapper.Map<ClientDto>(client);
            _repository.Delete(client);
            await _repository.Save();
            return data;
        }

        public async Task<IEnumerable<ClientDto>> GetAllPagination(int pageNumber, int pageSize)
        {
            var clients = await _clientRepositoryService.GetAllInclude(pageNumber, pageSize);
            return clients.Where(client => client.Status == true).
                Select(c => _mapper.Map<ClientDto>(c)).ToList();
        }

        public async Task<ClientDto> GetById(int id)
        {
            var client = await _repository.GetById(id);
            if (client == null) return null;
            var clientDto = _mapper.Map<ClientDto>(client);
            return clientDto;
        }

        public async Task<ClientDto> Update(int id, ClientDto clientDto)
        {
            var client = await _repository.GetById(id);
            if (client == null)
            {
                return null;
            }
            client.Status = clientDto.Status ?? true;
            client.Email = clientDto.Email;
            client.Dni = clientDto.Dni;
            client.Name = clientDto.Name;
            client.BirthDate = clientDto.BirthDate;
            client.PhoneNumber = clientDto.PhoneNumber;
            client.LastName = clientDto.LastName;
            _repository.Update(client);
            await _repository.Save();
            return clientDto;
        }
    }
}
