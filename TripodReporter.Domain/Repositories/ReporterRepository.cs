using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripodReporter.Domain.Contexts;

namespace TripodReporter.Domain.Repositories
{
    /// <summary>
    /// Generic Repository that Implements IRepository<typeparamref name="T"/>
    /// It Works with Application's EF Context and handles basic CRUD and Disposing
    /// of Resources afterwards. IRepository has a generic constraint stipulating that
    /// T must be a class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class ReporterRepository<T> : IRepository<T> where T : class
    {
        private ReporterContext db;
        private DbSet<T> set { get; set; }

        public ReporterRepository(ReporterContext dbParam)
        {
            db = dbParam;
            set = db.Set<T>();
        }

        public void Add(T t)
        {
            set.Add(t);
        }

        public void Delete(T t)
        {
            set.Remove(t);
        }

        public void AddOrUpdate(T t)
        { //check the state of the entity to see if it is being tracked by context which means its been modified
            if(db.Entry(t).State == EntityState.Detached)
            {
                db.Set<T>().Attach(t);
                db.Entry(t).State = EntityState.Modified;
            }
        }

        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
