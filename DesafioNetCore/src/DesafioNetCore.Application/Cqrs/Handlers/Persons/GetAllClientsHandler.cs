using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class GetAllClientsHandler : IRequestHandler<GetAllClientsRequest, GetAllClientsResponse>
{
    public Task<GetAllClientsResponse> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
