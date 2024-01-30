using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class GetAllClientsHandler : IRequestHandler<GetAllClientsRequest, IEnumerable<GetAllClientsResponse>>
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;
    public GetAllClientsHandler(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetAllClientsResponse>> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<GetAllClientsResponse>>(await _personService.GetClientsAsync());
    }

}
