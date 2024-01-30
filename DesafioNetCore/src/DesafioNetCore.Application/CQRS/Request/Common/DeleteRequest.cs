namespace DesafioNetCore.Application;

public abstract class DeleteRequest 
{
    //public Guid Id { get; } = Guid.NewGuid();
    public string ShortId { get; set; } = string.Empty;
}
