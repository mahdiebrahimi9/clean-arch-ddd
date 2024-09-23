using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.ProductsAgg.Events
{
    public class ProductCreated : BaseDomainEvent
    {
        public ProductCreated(long id, string bookName)
        {
            Id = id;
            BooKName = bookName;
        }
        public long Id { get; private set; }
        public string BooKName { get; private set; }
    }
}
