using MediatR;
using System.ComponentModel;

namespace DesafioNetCore.Application.Cqrs;

public class CreatePersonRequest : IRequest<CreatePersonResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    [DefaultValue(false)]
    public bool CanBuy { get; set; }
    public string Observations { get; set; } = string.Empty;
    public string AlternativeIdentifier { get; set; } = string.Empty;
    public bool Enable { get; set; } = true;
}
