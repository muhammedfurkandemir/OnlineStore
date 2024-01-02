namespace OnlineStore.Models.DTOs
{
    public class ProductDetailDto
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public short UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Description { get; set; }
    }
}
