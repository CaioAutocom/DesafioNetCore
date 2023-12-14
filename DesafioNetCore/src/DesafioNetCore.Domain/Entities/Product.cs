namespace DesafioNetCore.Domain.Entities;
public class Product
{
    public required string FullDescription { get; set; } = string.Empty;
    public required string ShortDescription { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public decimal Storage { get; set; }
    public required string BarCode { get; set; }
    public bool CanSell { get; set; }
    public bool Active { get; set; }
    public Guid IdUnit { get; set; }
    public required Unit Unit { get; set; }
}
