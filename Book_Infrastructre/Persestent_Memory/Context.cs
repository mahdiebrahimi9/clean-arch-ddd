using Book_Domain.Orders;
using Book_Domain.Products;

namespace Book_Infrastructre.Persestent_Memory
{
    public class Context
    {

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> Orders { get; set; } = new List<Order>() { new Order(1) };

    }
}
