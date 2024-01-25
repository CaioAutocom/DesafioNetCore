using MediatR;
namespace DesafioNetCore.Application.Cqrs;

public class GetByShortIdHandler : IRequestHandler<GetPersonByShortIdRequest, GetPersonByShortIdResponse>
{
    public Task<GetPersonByShortIdResponse> Handle(GetPersonByShortIdRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
