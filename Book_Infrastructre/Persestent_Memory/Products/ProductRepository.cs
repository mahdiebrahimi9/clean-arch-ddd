using Book_Domain.Products;
using Book_Domain.Products.Repositorey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Book_Infrastructre.Persestent_Memory.Products
{
    public class ProductRepository : IProductRepository
    {
        private Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            //var oldProduct = GetById(product.Id);
            //_context.Products.Remove(oldProduct);
            //Add(product);
        }

        public async Task<Product> GetById(long productId)
        {
            var result =  _context.Products.FirstOrDefault(f => f.Id == productId);
            return await Task.FromResult(result);
        }

        public List<Product> GetList()
        {
            return _context.Products;
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task Save()
        {
            //
        }

        public bool IsProductExsist(long productId)
        {
            return _context.Products.Any(f => f.Id == productId);
        }
    }
}
