using Book_Application.Products.DTOs;
using Book_Domain.Products;
using Book_Domain.Products.Repositorey;
using Book_Domain.Shared;

namespace Book_Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(AddProductDto dtoCommand)
        {
            var product = new Product(dtoCommand.BookName, Money.FromToman(dtoCommand.Price));
            _productRepository.Add(product);
            _productRepository.Save();
        }

        public void EditProduct(EditProductDto dtoCommand)
        {
            var product = _productRepository.GetById(dtoCommand.Id);
            product.EditBook(dtoCommand.BookName, Money.FromToman(dtoCommand.Price));
            _productRepository.Update(product);
            _productRepository.Save();
        }

        public ProductDto GetProductById(long id)
        {
            var product = _productRepository.GetById(id);
            return new ProductDto()
            {
                Id = product.Id,
                BookName = product.BookName,
                Price = product.Price.Value,
            };
        }

        public List<ProductDto> GetProducts()
        {
            return _productRepository.GetList().Select(product =>
            new ProductDto()
            {
                Id = product.Id,
                BookName = product.BookName,
                Price = product.Price.Value,
            }).ToList();
        }
    }
}
