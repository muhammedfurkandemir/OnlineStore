using OnlineStore.Models.Entities;
using OnlineStore.Models.ViewModels;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.DataAccess.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        public List<UserOrderViewModel> GetAllByUserId(string userId);

        public OrderDetailsViewModel GetOrderDetails(int id);

        public List<Order> GetAllByOrderDateDescending();
    }
}
