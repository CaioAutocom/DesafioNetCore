using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class GetAllPersonsRequest : IRequest<IEnumerable<GetAllPersonsResponse>>
{
}
