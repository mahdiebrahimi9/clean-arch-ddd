using Book_Domain.Products;
using Book_Queary.Products.DTOs;

namespace Book_Queary.Products
{
    public class ProductMapper
    {
        public static ProductDto MapProductToDto(Product product)
        {
            if (product == null)
                return null;

            return new ProductDto()
            {
                Id = product.Id,
                BookName = product.BookName,
                Description = product.Description,
                Price = product.Money,
                Images=product.Images.ToList(),
            };

        }
    }
}
