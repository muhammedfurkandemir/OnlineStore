using OnlineStore.Models.Abstract;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.Models.Concrete
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
        }
    }
}
