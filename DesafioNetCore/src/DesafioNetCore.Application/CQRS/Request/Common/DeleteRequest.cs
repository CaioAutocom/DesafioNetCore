using DesafioNetCore.Domain.Entities.Common;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class DeleteRequest : EntityBase, IRequest<bool>
{
}
