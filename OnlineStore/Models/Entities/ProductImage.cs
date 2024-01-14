using OnlineStore.Models.Abstract;

namespace OnlineStore.Models.Entities
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }
    }
}
