using System.Text;

namespace DesafioNetCore.Domain.Entities.Common;

public abstract class EntityBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public string ShortId { get; } = Guid.NewGuid().ToString("N")[..10];
}
