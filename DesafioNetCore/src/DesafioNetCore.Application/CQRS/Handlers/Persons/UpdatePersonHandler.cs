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
        var existingoPerson = await _personService.GetByShortIdAsync(request.ShortId);

        if (existingoPerson == null)
        {
            throw new ArgumentException("tratar essa parte aqui depois");
        }

        // atualiza a unidade existente com a que veio no request
        _mapper.Map(request, existingoPerson);

        await _personService.UpdateAsync(existingoPerson);

        //tratarrr
        return new UpdatePersonResponse();
    }
}
