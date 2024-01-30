using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class GetAllPersonHandler : IRequestHandler<GetAllPersonsRequest, IEnumerable<GetAllPersonsResponse>>
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;
    public GetAllPersonHandler(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetAllPersonsResponse>> Handle(GetAllPersonsRequest request, CancellationToken cancellationToken)
    {
        return await _mapper.Map<IEnumerable<GetAllPersonsResponse>>(await _personService.GetAllAsync());
    }

   
}
