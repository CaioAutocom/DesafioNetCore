using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}
