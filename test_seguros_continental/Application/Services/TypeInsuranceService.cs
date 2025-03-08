using AutoMapper;
using test_seguros_continental.Application.Interfaces;
using test_seguros_continental.Application.Interfaces.Repository;
using test_seguros_continental.Domain.Entities.TypeInsurance;
using test_seguros_continental.WebApi.DTOs.TypeInsurance;

namespace test_seguros_continental.Application.Services
{
    public class TypeInsuranceService : ITypeInsuranceService
    {
        IRepository<TypeInsuranceEntity> _repository;
        IMapper _mapper;

        public TypeInsuranceService(
            IRepository<TypeInsuranceEntity> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TypeInsuranceDto> Create(TypeInsuranceDto typeInsuranceDto)
        {
            await _repository.Add(_mapper.Map<TypeInsuranceEntity>(typeInsuranceDto));
            await _repository.Save();
            return typeInsuranceDto;
        }

        public async Task<TypeInsuranceDto> Delete(int id)
        {
            var typeInsurance = await _repository.GetById(id);
            if (typeInsurance == null)
            {
                return null;
            }
            var data = _mapper.Map<TypeInsuranceDto>(typeInsurance);
            _repository.Delete(typeInsurance);
            await _repository.Save();
            return data;
        }

        public async Task<IEnumerable<TypeInsuranceDto>> GetAll()
        {
            var typeInsurance = await _repository.GetAll();
            return typeInsurance.Where(type => type.Status == true).Select(c => _mapper.Map<TypeInsuranceDto>(c)).ToList();
        }

        public async Task<TypeInsuranceDto> Update(int id, TypeInsuranceDto typeInsuranceDto)
        {
            var typeInsurance = await _repository.GetById(id);
            if (typeInsurance == null)
            {
                return null;
            }
            typeInsurance.Status = typeInsuranceDto.Status;
            typeInsurance.Name = typeInsuranceDto.Name;
            _repository.Update(typeInsurance);
            await _repository.Save();
            return typeInsuranceDto;
        }
    }
}
