using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class GetPersonByShortIdRequest : IRequest<GetPersonByShortIdResponse>
{
    public string ShortId { get; set; } = string.Empty;
}
