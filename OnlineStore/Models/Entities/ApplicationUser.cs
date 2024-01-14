using Microsoft.AspNetCore.Identity;
using OnlineStore.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Entities
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        [Required]
        public string? IdentityNumber { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
