using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using LibraryManager.Data.EF.DatabaseContext;
using LibraryManager.Data.Model;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.Data.EF
{
    public abstract class Repository<T>: IRepository<T> where T: EntityBase, new()
    {
        protected LibraryManagerContext Context { get; } = new LibraryManagerContext();
        protected abstract DbSet<T> DbSet { get; }

        protected DbEntityEntry<T> Entry(T entity)
            => Context.Entry(entity);

        public virtual IQueryable<T> Query()
            => DbSet;

        public long Total()
            => DbSet.LongCount();

        public int Add(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();

            return entity.Id;
        }

        public void Update(T entity)
        {
            Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = new T {Id = id};
            DbSet.Attach(entity);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}