using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models.Entities;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.DataAccess.Concrete
{
    public class OrderLineRepository : RepositoryBase<OrderLine>, IOrderLineRepository
    {
        private OnlineStoreContext _onlineStoreContext;
        public OrderLineRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }
        public List<OrderLine> GetOrderLinesByOrderId(int id)
        {
            return _onlineStoreContext.OrderLines.Where(o => o.OrderId == id).ToList();
        }
        public void DeleteByRange(List<OrderLine> orderLines)
        {
            _onlineStoreContext.OrderLines.RemoveRange(orderLines);
        }
    }
}
