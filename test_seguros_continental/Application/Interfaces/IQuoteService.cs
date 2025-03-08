using test_seguros_continental.WebApi.DTOs.Quote;

namespace test_seguros_continental.Application.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteDTO>> GetAllPagination(int pageNumber, int pageSize);
        Task<QuoteDTO> GetById(int id);
        Task<QuoteDTO> Create(QuoteDTO quoteDTO);
        Task<QuoteDTO> Update(int id, QuoteDTO quoteDTO);
        Task<QuoteDTO> Delete(int id);
    }
}
