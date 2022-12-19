using System.Collections.Generic;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Red_Mojatablica> Mojatablica { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
