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

        // This will create a table in the database
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Action", DisplayOrder = 1 }, new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 }, new Category { Id = 3, Name = "History", DisplayOrder = 3 });
        }
    }
}