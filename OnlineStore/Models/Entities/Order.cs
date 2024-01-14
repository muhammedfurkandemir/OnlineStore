using OnlineStore.Models.Abstract;
using OnlineStore.Models.Concrete;

namespace OnlineStore.Models.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public string? OrderNumber { get; set; }

        public EnumOrderState OrderState { get; set; }

        public decimal Total { get; set; }

        public DateTime OrderDate { get; set; }

        public string? UserName { get; set; }

        public string? AdressName { get; set; }

        public string? Adress { get; set; }

        public string? City { get; set; }

        public string? District { get; set; }

        public string? Street { get; set; }

        public string? HomeNo { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }
    }
}
