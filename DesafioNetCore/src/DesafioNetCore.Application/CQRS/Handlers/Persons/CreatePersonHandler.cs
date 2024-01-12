using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using MediatR;

namespace DesafioNetCore.Application.CQRS.Handlers.Units;

public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;
    public CreatePersonHandler(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    public async Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var newPerson = _mapper.Map<Person>(request);
        return _mapper.Map<CreatePersonResponse>(await _personService.AddAsync(newPerson));
    }
}
