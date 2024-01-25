
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class DeletePersonRequest : DeleteRequest, IRequest<bool>
{
}
