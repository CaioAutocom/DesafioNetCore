using AutoMapper;
using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.CQRS.Handlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public UpdatePersonHandler(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        var existingPerson = await _personService.GetByShortIdAsync(request.ShortId);

        if (existingPerson == null) throw new Exception("Something went wrong. There is no any register with the given request.");
     
        // atualiza a pessoa existente com a que veio no request
        _mapper.Map(request, existingPerson);

        await _personService.UpdateAsync(existingPerson);
        // tirar dúvida se essa é a prática correta, onde recebo o request, carrego a pessoa, mapeio o request para a pessoa que está sendo trackeada, e após o update, mapeio o request para um novo response.
        return _mapper.Map(existingPerson, new UpdatePersonResponse());
    }
}
