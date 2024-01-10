using OnlineStore.Models.Abstract;
using OnlineStore.Models.Concrete;

namespace OnlineStore.Models.DTOs
{
    public class HomeViewDto:IDto
    {
            public List<Category> Categories { get; set; }
            public List<Product> Products { get; set; }
        
    }
}
