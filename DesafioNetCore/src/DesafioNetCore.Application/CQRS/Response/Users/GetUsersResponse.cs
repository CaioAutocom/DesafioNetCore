using DesafioNetCore.Domain.Entities;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class GetUsersResponse : IRequest<User>
{
    public string ShortId { get; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
}
