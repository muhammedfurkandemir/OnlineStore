using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models.Entities;
using OnlineStore.Models.ViewModels;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.DataAccess.Concrete
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private OnlineStoreContext _onlineStoreContext;
        public OrderRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        public List<Order> GetAllByOrderDateDescending()
        {
            return _onlineStoreContext.Orders.OrderByDescending(o=>o.OrderDate).ToList();
        }

        public List<UserOrderViewModel> GetAllByUserId(string userId)
        {
            var result= from order in _onlineStoreContext.Orders.Where(o => o.UserId == userId)
                        select new UserOrderViewModel 
                        {
                            Id = order.Id,
                            UserId = order.UserId,
                            OrderDate = order.OrderDate,
                            OrderNumber = order.OrderNumber,
                            OrderState = order.OrderState,
                            Total = order.Total
                        };
            return result.OrderByDescending(o=>o.OrderDate).ToList();

        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            var result = from order in _onlineStoreContext.Orders.Where(o => o.Id == id)
                         select new OrderDetailsViewModel
                         {
                             OrderId = order.Id,
                             UserName = order.UserName,
                             Total = order.Total,
                             OrderNumber = order.OrderNumber,
                             OrderState = order.OrderState,
                             OrderDate = order.OrderDate,
                             AdressName = order.AdressName,
                             Adress = order.Adress,
                             City = order.City,
                             District = order.District,
                             Street = order.Street,
                             HomeNo = order.HomeNo,
                             OrderLines = order.OrderLines.Select(orderlines => new OrderLineDetailsViewModel
                             {
                                 Id=orderlines.Id,
                                 ProductId=orderlines.ProductId,
                                 ProductName=orderlines.Product.ProductName,
                                 ImageUrl=orderlines.Product.ImageUrl,
                                 Price=orderlines.Price,
                                 Quantity= orderlines.Quantity
                             }).ToList()
                         };

            return result.FirstOrDefault();

        }
    }
}
