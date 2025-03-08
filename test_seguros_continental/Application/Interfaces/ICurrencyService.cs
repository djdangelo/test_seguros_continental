using test_seguros_continental.WebApi.DTOs.Currency;

namespace test_seguros_continental.Application.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDto>> GetAll();
        Task<CurrencyDto> Create(CurrencyDto currencyDto);
        Task<CurrencyDto> Update(int id, CurrencyDto currencyDto);
        Task<CurrencyDto> Delete(int id);
    }
}
