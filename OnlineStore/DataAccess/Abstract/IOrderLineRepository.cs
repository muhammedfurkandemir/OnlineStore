using OnlineStore.Models.Entities;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.DataAccess.Abstract
{
    public interface IOrderLineRepository : IRepository<OrderLine>
    {
        public List<OrderLine> GetOrderLinesByOrderId(int id);

        public void DeleteByRange(List<OrderLine> orderLines);
    }
}
