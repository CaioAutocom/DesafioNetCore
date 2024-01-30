using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class CreateProductRequest : IRequest<CreateProductResponse>
{
    public required string FullDescription { get; set; } = string.Empty;
    public required string ShortDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Storage { get; set; }
    public string BarCode { get; set; } = string.Empty;
    public bool CanSell { get; set; }
    public bool Active { get; set; }
    public required string Acronym { get; set; } = string.Empty;
}
