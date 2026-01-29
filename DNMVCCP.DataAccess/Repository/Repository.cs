using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DNMVCCP.DataAccess.Repository.IRepository;
using DNMVCCP.DataAccess.Data;
using Microsoft.EntityFrameworkCore;


namespace DNMVCCP.DataAccess.Repository
{
    // Generic Class Implementation
    // Type is Generic Class
    // Repository class is implementing IRepository
    public class Repository<T> : IRepository<T> where T : class
    {
        // we will implement the interface here
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        // DbSet<T> => Represents a table in the database
        // DbSet<T> => Represents the table of type T
        // T is an entity/model class (e.g. Category, Product, User)

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            // above line is equal to this
            // _db.categories == dbSet;
            // _db.products == dbSet;
            // _db.Set<T>() => It dynamically returns the correct DbSet
            // e.g: _db.Categories   // when T = Category
            //      _db.Products     // when T = Product
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            // _db.categories.Add == dbSet.Add;
            // _db.products.Add == dbSet.Add;
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            // dbSet implements IQueryable<T>
            // Query is not executed yet

            query = query.Where(filter);
            // Builds SQL WHERE clause

            return query.FirstOrDefault();
            // Executes SQL:
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();

            // IQueryable<T> → build query
            // ToList() → execute SQL
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

    }
}