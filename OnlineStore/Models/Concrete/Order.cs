using OnlineStore.Models.Abstract;

namespace OnlineStore.Models.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipCity { get; set; }
    }
}
