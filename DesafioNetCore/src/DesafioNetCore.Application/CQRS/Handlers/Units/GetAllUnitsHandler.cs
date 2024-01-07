using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.CQRS.Handlers.Units
{
    // implementar solução para o get
    //public class GetAllUnitsHandler : IRequestHandler<Unit, IEnumerable<GetAllUnitsResponse>>
    //{
    //    private readonly IUnitService _unitService;
    //    private readonly IMapper _mapper;

    //    public GetAllUnitsHandler(IUnitService unitService, IMapper mapper)
    //    {
    //        _unitService = unitService;
    //        _mapper = mapper;
    //    }

    //    public async Task<IEnumerable<GetAllUnitsResponse>> Handle(Unit request, CancellationToken cancellationToken)
    //    {
    //        var units = await _unitService.GetAllAsync();
    //        return _mapper.Map<IEnumerable<GetAllUnitsResponse>>(units);
    //    }
    //}
}
