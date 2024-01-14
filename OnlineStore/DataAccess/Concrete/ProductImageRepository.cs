using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models.Entities;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.DataAccess.Concrete
{
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
        }
    }
}
