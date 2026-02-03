using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNMVCCP.DataAccess.Data;
using DNMVCCP.Models;
using DNMVCCP.DataAccess.Repository.IRepository;

namespace DNMVCCP.DataAccess.Repository.IRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(db);
            Product = new ProductRepository(db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}