using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoList.Models.Database;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
