using test_seguros_continental.WebApi.DTOs.RateRange;

namespace test_seguros_continental.Application.Interfaces
{
    public interface IRateRangeService
    {
        Task<IEnumerable<RateRangeDto>> GetAll();
        Task<RateRangeDto> Create(RateRangeDto rateRangeDto);
        Task<RateRangeDto> Update(int id, RateRangeDto rateRangeDto);
        Task<RateRangeDto> Delete(int id);

    }
}
