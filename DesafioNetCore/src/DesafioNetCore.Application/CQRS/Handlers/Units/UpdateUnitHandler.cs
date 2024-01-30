using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

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
        var existingUnit = await _unitService.GetByShortIdAsync(request.ShortId) ?? throw new Exception("Something went wrong. There is no any register with the given request.");

        // atualiza a unidade existente com a que veio no request
        _mapper.Map(request, existingUnit);

        await _unitService.UpdateAsync(existingUnit);

        return _mapper.Map(existingUnit, new UpdateUnitResponse());
    }
}
