using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Abstract;
using System.Linq.Expressions;

namespace OnlineStore.Utilities.EntityFreamwork.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class,IEntity,new()
    {
        private OnlineStoreContext _onlineStoreContext;
        private DbSet<T> dbSet;

        public RepositoryBase(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
            dbSet = _onlineStoreContext.Set<T>();

        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            _onlineStoreContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            _onlineStoreContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            var entity = dbSet.FirstOrDefault(filter);
            return entity;
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            _onlineStoreContext.SaveChanges();
        }
    }
}
