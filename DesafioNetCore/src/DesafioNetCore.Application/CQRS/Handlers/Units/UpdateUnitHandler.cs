using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.CQRS.Handlers.Units
{
    public class UpdateUnitHandler : IRequestHandler<UpdateUnitRequest, UpdateUnitResponse>
    {
        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;

        public UpdateUnitHandler(IUnitService unitService, IMapper mapper)
        {
            _unitService = unitService;
            _mapper = mapper;
        }

        public async Task<UpdateUnitResponse> Handle(UpdateUnitRequest request, CancellationToken cancellationToken)
        {
            var existingUnit = await _unitService.GetByAcronym(request.Acronym);

            if (existingUnit == null)
            {
               throw new ArgumentException("tratar essa parte aqui depois");
            }
            
            // atualiza a unidade existente com a que veio no request
            _mapper.Map(request, existingUnit);

            await _unitService.UpdateAsync(existingUnit);


            //tratarrr
            return new UpdateUnitResponse() ;
        }
    }
}
