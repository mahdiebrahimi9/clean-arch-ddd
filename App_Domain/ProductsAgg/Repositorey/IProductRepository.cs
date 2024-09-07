namespace Book_Domain.Products.Repositorey
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        List<Product> GetList();
        Product GetById(long productId);
        void Save();
        bool IsProductExsist(long productId);
    }
}
