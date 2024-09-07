using Book_Application.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Application.Products
{
    public interface IProductService
    {
        void AddProduct(AddProductDto dtoCommand);
        void EditProduct(EditProductDto dtoCommand);
        ProductDto GetProductById(long id);
        List<ProductDto> GetProducts();

    }
}
