using DesafioNetCore.Application.CQRS;
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class DeleteUnitRequest : DeleteRequest, IRequest<bool>
{

}
