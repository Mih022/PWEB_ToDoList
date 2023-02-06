using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Collections.Generic;
using ToDoList.Models.Database;

namespace ToDoList.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoList.Models.Database.Topic> Topics { get; set; }
        public DbSet<ToDoList.Models.Database.Comment> Comments { get; set; }
        public DbSet<ToDoList.Models.Database.UserData> UserDatas { get; set; }
        public DbSet<ToDoList.Models.Database.PersonalData> PersonalDatas { get; set; }
        public DbSet<ToDoList.Models.Database.User_ToDo_Relation> User_ToDo_Relations { get; set; }

        //Za seedanje podataka, ako bude trebalo kasnije
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var ids = 1;
        //    var userFaker = new Faker<UserData>("hr")
        //        .RuleFor(m => m.Id, f => ids++)
        //        .RuleFor(x => x.FirstName, y => y.Person.FirstName)
        //        .RuleFor(x => x.LastName, y => y.Person.LastName);

        //    modelBuilder.Entity<UserData>().HasData(userFaker.GenerateBetween(10,20));
        //}
    }
}
