using Book_Domain.OrdersAgg.Services;
using Book_Domain.Products.Repositorey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Book_Application.Orders.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IProductRepository _productRepository;
        public OrderDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool IsProductNotExsist(long productId)
        {
            var isProductExsits = _productRepository.IsProductExsist(productId);
            return !isProductExsits;
        }
    }
}
