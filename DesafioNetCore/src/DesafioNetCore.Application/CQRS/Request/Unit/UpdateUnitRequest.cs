using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class UpdateUnitRequest : IRequest<UpdateUnitResponse>
{
    public string ShortId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
