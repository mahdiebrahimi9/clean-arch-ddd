using Book_Application.Orders;
using Book_Application.Orders.Services;
using Book_Application.Products;
using Book_Contract;
using Book_Domain.Orders.Repository;
using Book_Domain.OrdersAgg.Services;
using Book_Domain.Products.Repositorey;
using Book_Infrastructre.Persestent_Memory;
using Book_Infrastructre.Persestent_Memory.Orders;
using Book_Infrastructre.Persestent_Memory.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Book_Config
{
    public class ProjectBootstraper
    {
        public static void Init(IServiceCollection service)
        {
            service.AddTransient<IOrderService, OrderService>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<IOrderDomainService, OrderDomainService>();

            service.AddScoped<ISmsService, SmsService>();
            service.AddSingleton<Context>();
        }
    }
}
