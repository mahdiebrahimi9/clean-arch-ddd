using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.ProductsAgg
{
    public class ProductImage:BaseEntity
    {
        public long Id { get; private set; }
        public string ImageName { get; private set; }
        public Guid ProductId { get; private set; }

        public ProductImage(Guid productId, string imageName)
        {
            ImageName = imageName;
            ProductId = productId;
        }


    }
}
