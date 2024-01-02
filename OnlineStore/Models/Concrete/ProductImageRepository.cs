using OnlineStore.Models.Abstract;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.Models.Concrete
{
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
        }
    }
}
