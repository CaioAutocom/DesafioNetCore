using DesafioNetCore.Domain.Entities.Common;

namespace DesafioNetCore.Domain.Entities;
public class Product : EntityBase
{
    public required string FullDescription { get; set; } = string.Empty;
    public required string ShortDescription { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public decimal Storage { get; set; }
    public required string BarCode { get; set; }
    public bool CanSell { get; set; } = false;
    public bool Active { get; set; }
    public required string Acronym { get; set; } = string.Empty;
    public Unit Unit { get; set; }
}
