
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class DeletePersonRequest : DeleteRequest, IRequest<bool>
{
}
