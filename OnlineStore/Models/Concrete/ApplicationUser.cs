using Microsoft.AspNetCore.Identity;
using OnlineStore.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Concrete
{
    public class ApplicationUser :IdentityUser ,IEntity
    {
        [Required]
        public int IdentityNumber { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
