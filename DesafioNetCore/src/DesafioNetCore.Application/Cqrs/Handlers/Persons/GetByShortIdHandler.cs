using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;
namespace DesafioNetCore.Application.Cqrs;

public class GetByShortIdHandler : IRequestHandler<GetPersonByShortIdRequest, GetPersonByShortIdResponse>
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public GetByShortIdHandler(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }
    public async Task<GetPersonByShortIdResponse> Handle(GetPersonByShortIdRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<GetPersonByShortIdResponse>(await _personService.GetByShortIdAsync(request.ShortId));
    }
}
