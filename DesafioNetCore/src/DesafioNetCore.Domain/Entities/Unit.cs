using DesafioNetCore.Domain.Entities.Common;

namespace DesafioNetCore.Domain.Entities;
public class Unit  : EntityBase
{
    public string Acronym { get; set; } = string.Empty; 
    public string Description { get; set; } 
    
    public ICollection<Product> Products { get; set;} = new List<Product>();
}
