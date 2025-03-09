using AutoMapper;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Application.Services.Repository;
using test_seguros_continental.Common.Email;
using test_seguros_continental.Domain.Entities.Quote;
using test_seguros_continental.WebApi.DTOs.Quote;

namespace test_seguros_continental.Application.Services
{
    public class QuoteService : IQuoteService
    {
        IRepository<QuoteEntity> _repository;
        QuoteRepositoryService _quoteRepositoryService;

        IRateRangeService _rangeService;
        IClientService _clientService;
       
        IMapper _mapper;
        public QuoteService(
                IRepository<QuoteEntity> repository,
                IMapper mapper,
                IRateRangeService rateRangeService, IClientService clientService,
                QuoteRepositoryService quoteRepositoryService
            )
        {
            _repository = repository;
            _mapper = mapper;
            _rangeService = rateRangeService;
            _clientService = clientService;
            _quoteRepositoryService = quoteRepositoryService;
        }

        public async Task<QuoteDTO> Create(QuoteDTO quoteDTO)
        {
            EmailService emailService = new EmailService();

            var rateRange = await _rangeService.GetAll();
            var client = await _clientService.GetById(quoteDTO.ClientId);

            double rateLocal = 0.0;

            foreach (var item in rateRange)
            {
                if (quoteDTO.TotalInsurance >= item.MountMin && quoteDTO.TotalInsurance <= item.MountMax)
                {
                    rateLocal = item.Rate;
                }
            }

            quoteDTO.CreateAt = DateTime.Now.ToUniversalTime();
            quoteDTO.Rate = rateLocal;
            quoteDTO.Status = true;
            quoteDTO.DownPayment = Common.GetDownPayment.DownPayment.GetDownPayment(rateLocal, quoteDTO.TotalInsurance); 

            await _repository.Add(_mapper.Map<QuoteEntity>(quoteDTO));
            await _repository.Save();

            string message = "Buen dia estimado(a) " + $"{client.Name}" + " " + $"{client.LastName}" 
                + ", se le notifica que su porcentaje de prima es: " + rateLocal + ", su prima inicial de: " 
                + quoteDTO.DownPayment + ", todo esto calculado sobre la suma asegurada de su bien la cual es: " 
                + quoteDTO.TotalInsurance + ". Saludos.";

            emailService.SendEmail(client.Email, "Cotizacion de seguro", message);

            return quoteDTO;
        }

        public async Task<QuoteDTO> Delete(int id)
        {
            var quote = await _repository.GetById(id);
            if (quote == null)
            {
                return null;
            }
            var data = _mapper.Map<QuoteDTO>(quote);
            _repository.Delete(quote);
            await _repository.Save();
            return data;
        }

        public async Task<IEnumerable<QuoteDTO>> GetAllPagination(int pageNumber, int pageSize)
        {
            var quotes = await _quoteRepositoryService.GetAllInclude(pageNumber, pageSize);
            return quotes.Where(client => client.Status == true).
                Select(c => _mapper.Map<QuoteDTO>(c)).ToList();
        }

        public async Task<QuoteDTO> GetById(int id)
        {
            var quote = await _repository.GetById(id);
            if (quote == null)
            {
                return null;
            }
            var quoteDto = _mapper.Map<QuoteDTO>(quote);
            return quoteDto;
        }

        public async Task<QuoteDTO> Update(int id, QuoteDTO quoteDTO)
        {
            var quote = await _repository.GetById(id);
            if (quote == null)
            {
                return null;
            }
            quote.Status = quoteDTO.Status;
            quote.DescriptionAsset = quoteDTO.DescriptionAsset;
            _repository.Update(quote);
            await _repository.Save();
            return quoteDTO;
        }
    }
}
