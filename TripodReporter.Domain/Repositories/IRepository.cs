using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Repositories
{
    /// <summary>
    /// IRepository is an Interface that addresses the basic abilities of the application
    /// towards a data store. This interface will serve for any number of types that 
    /// should have these abilities.
    /// </summary>
    /// <typeparam name="Tentity"></typeparam>
    public interface IRepository<Tentity> : IDisposable where Tentity : class
    {
        //the common behaviours that will be found among all my entities
        void Add(Tentity t);
        void Delete(Tentity t);
        void AddOrUpdate(Tentity t);
        void Commit();
       // IEnumerable<Tentity> GetAll(); //Return all possible objects of type Tentity
        //Expression<Delegate<typeone,ResultType>> what is a predicate? Predicates are functions that return true or false
        //Expression<Func<T,TResult>> name
        IQueryable<Tentity> Query (Expression<Func<Tentity, bool>> predicate);

        IEnumerable<Tentity> GetAll();

        Tentity GetById(int id);

        void Dispose();


    }
}
