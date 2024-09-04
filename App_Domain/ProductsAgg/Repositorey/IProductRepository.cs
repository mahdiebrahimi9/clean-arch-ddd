using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Products.Repositorey
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        List<Product> GetList();
        Product GetById(Guid productId);
        void Save();
        bool IsProductExsist(Guid productId);
    }
}
