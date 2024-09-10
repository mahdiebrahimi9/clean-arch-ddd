using Book_Domain.Shared;
using Book_Domain.Shared.Exceptions;

namespace Book_Domain.ProductsAgg
{
    public class ProductImage : BaseEntity
    {
        //public long Id { get; private set; }
        public string ImageName { get; private set; }
        public long ProductId { get; private set; }

        public ProductImage(long productId, string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                NullOrEmptyDomainDataException.CheckString(imageName, nameof(ImageName));

            ImageName = imageName;
            ProductId = productId;
        }


    }
}
