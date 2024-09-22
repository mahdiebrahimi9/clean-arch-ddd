namespace Book_Application.Products.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
    }
    public class AddProductDto
    {
        public string BookName { get; set; }
        public int Price { get; set; }
    }
    public class EditProductDto
    {
        public long Id { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
    }
}
