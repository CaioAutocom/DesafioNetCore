using DesafioNetCore.Domain.Entities.Common;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class DeleteRequest : IRequest<bool>
{
    //public Guid Id { get; } = Guid.NewGuid();
    public string ShortId { get; set; } = string.Empty;
}
