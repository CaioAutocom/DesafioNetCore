using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.Cqrs.Handlers;
public class CreateUnitHandler : IRequestHandler<CreateUnitRequest, CreateUnitResponse>
{
    private readonly IUnitService _unitService;
    private readonly IMapper _mapper;
    public CreateUnitHandler(IUnitService unitService, IMapper mapper)
    {
        _unitService = unitService;
        _mapper = mapper;
    }

    public async Task<CreateUnitResponse> Handle(CreateUnitRequest request, CancellationToken cancellationToken)
    {
        var newUnit = _mapper.Map<Domain.Entities.Unit>(request);
        return _mapper.Map<CreateUnitResponse>(await _unitService.AddAsync(newUnit));
    }
}
