using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineStore.Models.Abstract;
using System.ComponentModel;

namespace OnlineStore.Models.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [ValidateNever]
        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public short UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Description { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
