using AutoMapper;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Domain.Entities.Currency;
using test_seguros_continental.WebApi.DTOs.Currency;

namespace test_seguros_continental.Application.Services
{
    public class CurrencyService : ICurrencyService
    {
        IRepository<CurrencyEntity> _repository;
        IMapper _mapper;
        public CurrencyService(
             IRepository<CurrencyEntity> repository,
             IMapper mapper
            )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CurrencyDto> Create(CurrencyDto currencyDto)
        {
            await _repository.Add(_mapper.Map<CurrencyEntity>(currencyDto));
            await _repository.Save();
            return currencyDto;
        }

        public async Task<CurrencyDto> Delete(int id)
        {
            var currency = await _repository.GetById(id);
            if (currency == null)
            {
                return null;
            }
            var data = _mapper.Map<CurrencyDto>(currency);
            _repository.Delete(currency);
            await _repository.Save();
            return data;
        }

        public async Task<IEnumerable<CurrencyDto>> GetAll()
        {
            var currency = await _repository.GetAll();
            return currency.Where(type => type.Status == true).Select(c => _mapper.Map<CurrencyDto>(c)).ToList();
        }

        public async Task<CurrencyDto> Update(int id, CurrencyDto currencyDto)
        {
            var currency = await _repository.GetById(id);
            if (currency == null)
            {
                return null;
            }
            currency.Status = currencyDto.Status ?? true;
            currency.CurrencyName = currencyDto.CurrencyName;
            _repository.Update(currency);
            await _repository.Save();
            return currencyDto;
        }
    }
}
