using DNMVCCP.Models;
using Microsoft.EntityFrameworkCore;

// Missing using directive: The namespace where ApplicationDbContext is defined isn’t imported at the top of your file.

namespace DNMVCCP.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // This will create a category table in the database
        public DbSet<Category> Categories { get; set; }

        // This will create a product table in the database
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Book1", Author = "Waqas Nazir1", Description = "This is my first book", ISBN = "SW4345355435", ListPrice = 99, Price = 90, Price50 = 85, Price100 = 50 },
                new Product { Id = 2, Title = "Book2", Author = "Waqas Nazir2", Description = "This is my second book", ISBN = "SW4345355435", ListPrice = 99, Price = 90, Price50 = 85, Price100 = 50 },
                new Product { Id = 3, Title = "Book3", Author = "Waqas Nazir3", Description = "This is my third book", ISBN = "SW4345355435", ListPrice = 99, Price = 90, Price50 = 85, Price100 = 50 },
                new Product { Id = 4, Title = "Book4", Author = "Waqas Nazir4", Description = "This is my fourth book", ISBN = "SW4345355435", ListPrice = 99, Price = 90, Price50 = 85, Price100 = 50 },
                new Product { Id = 5, Title = "Book5", Author = "Waqas Nazir5", Description = "This is my fifth book", ISBN = "SW4345355435", ListPrice = 99, Price = 90, Price50 = 85, Price100 = 50 },
                new Product { Id = 6, Title = "Book6", Author = "Waqas Nazir6", Description = "This is my sixth book", ISBN="SW4345355435",ListPrice=99, Price=90,Price50=85, Price100=50 }
            );
        }
    }
}