using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DNMVCCP.DataAccess.Repository.IRepository
{
    // T is a Generic Class Type as we are creating generic interface class
    // where T : class => where T will be a class

    // NOTE:
    // Modifier	Meaning
    // public	Accessible from anywhere.
    // internal	Accessible only within the same assembly (project).
    // private	Only accessible within the containing type (rarely used on top-level types).
    public interface IRepository<T> where T : class
    {
        // T - will be category or product or any other generic modal
        // IEnumerable<T> => Returns all entities of type T as a collection.
        IEnumerable<T> GetAll();

        // As we will get the object that must match with the object of class type
        // T is a generic class. e.g: for Category it will be category
        // for Person it will be Person etc
        // Note: u => u.Id == id (Link Operation)
        // Expression<Func<T, bool>> filter => what we will be getting will be a function & return will be boolean
        // will name this as filter when we will be fetching the individual record.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);

        // void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
    }
}

// We will Implement Interface in other file