using OnlineStore.Models.Abstract;

namespace OnlineStore.Models.Concrete
{
    public class CartLine:IEntity
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
