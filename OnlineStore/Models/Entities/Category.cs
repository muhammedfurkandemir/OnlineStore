using OnlineStore.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name Is Not Empty!")] //not null
        [MaxLength(30)]
        public string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}
