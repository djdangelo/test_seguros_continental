using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Domain.Entities.TypeClient;
using test_seguros_continental.WebApi.DTOs.TypeClient;

namespace test_seguros_continental.Application.Services
{
    public class TypeClientService : ITypeClientService
    {
        IRepository<TypeClientEntity> _repository;
        IMapper _mapper;
        public TypeClientService(
            IRepository<TypeClientEntity> repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TypeClientDto> Create(TypeClientDto typeClientDto)
        {
            await _repository.Add(_mapper.Map<TypeClientEntity>( typeClientDto));
            await _repository.Save();
            return typeClientDto;
        }

        public async Task<TypeClientDto> Delete(int id)
        {
            var typeClient = await _repository.GetById(id);
            if (typeClient == null)
            {
                return null;
            }
            var data = _mapper.Map<TypeClientDto>( typeClient);
            _repository.Delete(typeClient);
            await _repository.Save();
            return data;
        }

        public async Task<IEnumerable<TypeClientDto>> GetAll()
        {
            var typeClients = await _repository.GetAll();
            return typeClients.Where(type => type.Status == true).Select(c => _mapper.Map<TypeClientDto>( c)).ToList();
        }

        public async Task<TypeClientDto> Update(int id, TypeClientDto typeClientDto)
        {
            var typeClient = await _repository.GetById( id );
            if (typeClient == null)
            {
                return null;
            }
            typeClient.Status = typeClientDto.Status;
            typeClient.TypeName = typeClientDto.TypeName;
            _repository.Update( typeClient );
            await _repository.Save();
            return typeClientDto;
        }
    }
}
