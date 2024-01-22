using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class CreateProductResponse : IRequest<CreateProductResponse>
{
    public string ShortId { get; set; } = string.Empty;

    public required string FullDescription { get; set; } = string.Empty;
    public required string ShortDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Storage { get; set; }
    public required string BarCode { get; set; }
    public bool CanSell { get; set; }
    public bool Active { get; set; }
    public required string Acronym { get; set; } = string.Empty;
}
