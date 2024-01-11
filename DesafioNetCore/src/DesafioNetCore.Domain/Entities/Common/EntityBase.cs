using System.Text;

namespace DesafioNetCore.Domain.Entities.Common;

public abstract class EntityBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public string ShortId { get; private set; }
   
    protected EntityBase() { 
        ShortId = ShortIdExtension.ToBase64(Id.ToString("N"));
    }

}
