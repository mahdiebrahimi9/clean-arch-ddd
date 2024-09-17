using Book_Domain.Products;
using Book_Domain.Products.Repositorey;
using Microsoft.EntityFrameworkCore;

namespace Book_Infrastructre.Persestent.Ef.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly BookDbContext _context;
        public ProductRepository(BookDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Add(product);
        }

        public async Task<Product> GetById(long productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public List<Product> GetList()
        {
            return _context.Products.ToList();
        }

        public bool IsProductExsist(long productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
