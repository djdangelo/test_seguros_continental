using AutoMapper;
using test_seguros_continental.Domain.Entities.Client;
using test_seguros_continental.Domain.Entities.Currency;
using test_seguros_continental.Domain.Entities.Quote;
using test_seguros_continental.Domain.Entities.RateRange;
using test_seguros_continental.Domain.Entities.TypeClient;
using test_seguros_continental.Domain.Entities.TypeInsurance;
using test_seguros_continental.WebApi.DTOs.Client;
using test_seguros_continental.WebApi.DTOs.Currency;
using test_seguros_continental.WebApi.DTOs.Quote;
using test_seguros_continental.WebApi.DTOs.RateRange;
using test_seguros_continental.WebApi.DTOs.TypeClient;
using test_seguros_continental.WebApi.DTOs.TypeInsurance;


namespace test_seguros_continental.Application.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ClientDto, ClientEntity>();
            CreateMap<TypeClientDto, TypeClientEntity>();
            CreateMap<CurrencyDto, CurrencyEntity>();
            CreateMap<TypeInsuranceDto, TypeInsuranceEntity>();
            CreateMap<RateRangeDto, RateRangeEntity>();
            CreateMap<QuoteDTO, QuoteEntity>();

            CreateMap<ClientEntity, ClientDto>().ForMember(dto => dto.ClientId, m => m.MapFrom(b => b.ClientId));
            CreateMap<TypeClientEntity, TypeClientDto>().ForMember(dto => dto.TypeClientId, m => m.MapFrom(b => b.TypeClientId));
            CreateMap<CurrencyEntity, CurrencyDto>().ForMember(dto => dto.CurrencyId, m => m.MapFrom(b => b.CurrencyId));
            CreateMap<TypeInsuranceEntity, TypeInsuranceDto>().ForMember(dto => dto.TypeInsuranceId, m => m.MapFrom(b => b.TypeInsuranceId));
            CreateMap<RateRangeEntity, RateRangeDto>().ForMember(dto => dto.RateRangeId, m => m.MapFrom(b => b.RateRangeId));
            CreateMap<QuoteEntity, QuoteDTO>().ForMember(dto => dto.QuoteId, m => m.MapFrom(b => b.QuoteId));
        }
    }
}
