using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class UpdateUnitRequest : IRequest<UpdateUnitResponse>
{
    public string ShortId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
