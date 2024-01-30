using DesafioNetCore.Application.Cqrs;
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class DeleteUnitRequest : DeleteRequest, IRequest<bool>
{

}
