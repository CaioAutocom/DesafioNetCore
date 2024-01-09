using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class DeletePersonHandler : IRequestHandler<DeleteRequest, bool>
{
    private readonly IPersonService _personService;
    public DeletePersonHandler(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task<bool> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {
        return await _personService.DeleteAsync(request.ShortId);
    }
}
