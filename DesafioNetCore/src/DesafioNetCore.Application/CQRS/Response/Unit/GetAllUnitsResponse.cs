using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class GetAllUnitsResponse : IRequest<Domain.Entities.Unit>
{
    public string Acronym { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
