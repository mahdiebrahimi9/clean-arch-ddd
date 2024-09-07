using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.OrdersAgg.Services
{
    public interface IOrderDomainService
    {
        bool IsProductNotExsist(long productId);
    }
}
