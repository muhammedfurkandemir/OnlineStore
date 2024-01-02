using OnlineStore.Models.Abstract;
using System.Linq.Expressions;

namespace OnlineStore.Utilities.EntityFreamwork.Repositories
{
    public interface IRepository<T> where T : class,IEntity, new()
    {
         List<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
