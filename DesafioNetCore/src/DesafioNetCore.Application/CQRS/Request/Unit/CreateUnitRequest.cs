namespace DesafioNetCore.Application.CQRS;

public class CreateUnitRequest
{
    public string Acronym { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
