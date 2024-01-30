using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class GetAllClientsRequest : IRequest<IEnumerable<GetAllClientsResponse>>
{

}
