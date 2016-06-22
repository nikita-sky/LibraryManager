using System.Linq;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.Data.Model
{
    public interface IRepository<T> where T: EntityBase
    {
        IQueryable<T> Query();
        long Total();

        int Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
    }
}