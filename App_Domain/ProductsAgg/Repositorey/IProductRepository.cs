namespace Book_Domain.Products.Repositorey
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        List<Product> GetList();
        Task<Product> GetById(long productId);
        Task Save();
        bool IsProductExsist(long productId);
    }
}
