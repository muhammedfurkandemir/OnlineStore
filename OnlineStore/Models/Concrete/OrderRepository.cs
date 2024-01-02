using OnlineStore.Models.Abstract;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.Models.Concrete
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
        }
    }
}
