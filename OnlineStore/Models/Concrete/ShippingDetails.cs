using OnlineStore.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Concrete
{
    public class ShippingDetails
    {
        [Required()]
        public string? FullName { get; set; }
        [Required()]
        public string? AdressName { get; set;}
        [Required()]
        public string? Address { get; set; }
        [Required()]
        public string? City { get; set; }

        [Required()]
        public string? District { get; set;}

        [Required()]
        public string? Street { get; set; }

        [Required()]
        public string? HomeNo { get; set; }

        
    }
}
