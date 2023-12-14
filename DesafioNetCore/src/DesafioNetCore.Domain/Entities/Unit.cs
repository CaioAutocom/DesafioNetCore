using DesafioNetCore.Domain.Entities.Common;

namespace DesafioNetCore.Domain.Entities;
public class Unit : EntityBase
{
    public string Acronym { get; set; } 
    public string Description { get; set; } 
}
