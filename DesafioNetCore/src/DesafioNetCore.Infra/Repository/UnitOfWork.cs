using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DesafioNetCore.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IdentityContext _identitycontext;

        public UnitOfWork(AppDbContext appDbContext, IdentityContext identitycontext)
        {
            _context = appDbContext;
            _identitycontext = identitycontext;
        }
        private IUserRespository _userRespository;
        public IUserRespository UserRespository
        {
            get => _userRespository ??= new UserRepository(_identitycontext);
        }

        // lembrar de explicar o motivo dessa abordagem.
        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get => _productRepository ??= new ProductRepository(_context);
        }

        private IUnitRepository _unitRepository;
        public IUnitRepository UnitRepository
        {
            get => _unitRepository ??= new UnitRepository(_context);
        }

        private IPersonRepository _personRepository;
        public IPersonRepository PersonRepository
        {
            get => _personRepository ??= new PersonRepository(_context);
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
        public bool CommitIdentity()
        {
            return _identitycontext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _identitycontext.Dispose();
            _context.Dispose();
        }
    }
}
