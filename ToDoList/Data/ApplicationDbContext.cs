using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoList.Models.Database;

namespace ToDoList.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserData, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoList.Models.Database.Topic> Topic { get; set; }
        public DbSet<ToDoList.Models.Database.Comment> Comment { get; set; }
    }
}
