using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesafioNetCore.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _appDbContext.Products.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }
        // não será usado
        public async Task<Product> GetByIdAsync(Guid guid)
        {
            return await _appDbContext.Products.FindAsync(guid);
        }
        public async Task<Product> GetByAcronym(string acronym)
        {
            return await _appDbContext.Products.FindAsync(acronym);
        }

        public async Task<Product> GetByShortIdAsync(string shortId)
        {
            return await _appDbContext.Products.Include(x => x.Unit).SingleOrDefaultAsync(u => u.ShortId == shortId);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<bool> DeleteAsync(string shortId)
        {
            var existingProduct = await _appDbContext.Products.SingleOrDefaultAsync(x => x.ShortId == shortId) ?? throw new Exception("Product not found.");
            return _appDbContext.Remove(existingProduct) != null;
        }

        public async Task<bool> BarCodeDoesNotExistAsync(string barCode)
        {
            return await _appDbContext.Products.SingleOrDefaultAsync(x => x.BarCode == barCode) == null;
        }

        public async Task<List<Product>> GetAllVendableProducts()
        {
            return await _appDbContext.Products.Where(x => x.CanSell == true).ToListAsync();
        }

        public async Task<Product> GetQueryable(Expression<Func<Product, bool>> query)
        {
            return await _appDbContext.Products.SingleOrDefaultAsync(query);
        }
    }
}
