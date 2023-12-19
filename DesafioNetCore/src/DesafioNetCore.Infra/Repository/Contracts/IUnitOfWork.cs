namespace DesafioNetCore.Infra.Repository.Contracts;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
    bool CommitIdentity();
    public IPersonRepository PersonRepository { get; }
    public IUnitRepository UnitRepository { get; }
    public IUserRespository UserRespository { get; }
    public IProductRepository ProductRepository { get; }
}
