using OnlineStore.DataAccess.Abstract;
using OnlineStore.Models.Entities;
using OnlineStore.Utilities.EntityFreamwork;
using OnlineStore.Utilities.EntityFreamwork.Repositories;

namespace OnlineStore.DataAccess.Concrete
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineStoreContext onlineStoreContext) : base(onlineStoreContext)
        {
        }
    }
}
