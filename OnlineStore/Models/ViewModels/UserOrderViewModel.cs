using OnlineStore.Models.Abstract;
using OnlineStore.Models.Concrete;

namespace OnlineStore.Models.ViewModels
{
    public class UserOrderViewModel:IViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string? UserId { get; set; }

        public EnumOrderState OrderState { get; set; }

        public string? OrderNumber { get; set; }

        public DateTime OrderDate  { get; set; }

        public decimal Total { get; set; }
    }
}
