using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class CreatePersonResponse : IRequest<CreatePersonResponse>
{
    public string ShortId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    public bool CanBuy { get; set; }
    public string Observations { get; set; } = string.Empty;
    public string AlternativeIdentifier { get; set; } = string.Empty;
    public bool Enable { get; set; } = true;
}
