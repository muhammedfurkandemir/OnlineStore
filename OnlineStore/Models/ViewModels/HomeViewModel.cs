using OnlineStore.Models.Abstract;
using OnlineStore.Models.Entities;

namespace OnlineStore.Models.ViewModels
{
    public class HomeViewModel : IViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

    }
}
