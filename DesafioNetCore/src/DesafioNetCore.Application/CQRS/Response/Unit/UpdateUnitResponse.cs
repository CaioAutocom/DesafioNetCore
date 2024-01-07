using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class UpdateUnitResponse : IRequest<UpdateUnitResponse>
{
    public string Acronym { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
