using Book_Domain.ProductsAgg;
using Book_Domain.Shared;

namespace Book_Queary.Products.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string BookName { get; set; }
        public Money Price { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
