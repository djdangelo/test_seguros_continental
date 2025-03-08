using AutoMapper;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Domain.Entities.RateRange;
using test_seguros_continental.WebApi.DTOs.RateRange;

namespace test_seguros_continental.Application.Services
{
    public class RateRangeService : IRateRangeService
    {
        IRepository<RateRangeEntity> _repository;
        IMapper _mapper;
        public RateRangeService(
            IRepository<RateRangeEntity> repository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<RateRangeDto> Create(RateRangeDto rateRangeDto)
        {
            await _repository.Add(_mapper.Map<RateRangeEntity>(rateRangeDto));
            await _repository.Save();
            return rateRangeDto;
        }

        public async Task<RateRangeDto> Delete(int id)
        {
            var rateRange = await _repository.GetById(id);
            if (rateRange == null)
            {
                return null;
            }
            var data = _mapper.Map<RateRangeDto>(rateRange);
            _repository.Delete(rateRange);
            await _repository.Save();
            return data;

        }

        public async Task<IEnumerable<RateRangeDto>> GetAll()
        {
            var ranteRange = await _repository.GetAll();
            return ranteRange.Where(type => type.Status == true).Select(c => _mapper.Map<RateRangeDto>(c)).ToList();
        }

        public async Task<RateRangeDto> Update(int id, RateRangeDto rateRangeDto)
        {
            var rateRange = await _repository.GetById(id);
            if (rateRange == null)
            {
                return null;
            }
            rateRange.Status = rateRangeDto.Status ?? true;
            rateRange.MountMin = rateRange.MountMin;
            rateRange.MountMax = rateRange.MountMax;
            rateRange.Rate = rateRangeDto.Rate;
            _repository.Update(rateRange);
            await _repository.Save();
            return rateRangeDto;
        }
    }
}
