using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace ToDoList.Models.Database
{
    public class UserData : IdentityUser
    {

        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        public string Bio { get; set; }


        public static Faker<UserData> GetFaker()
        {
            return new Faker<UserData>("hr")
                .RuleFor(x => x.UserName, y => y.Person.FirstName + y.Person.LastName)
                .RuleFor(x => x.FirstName, y => y.Person.FirstName)
                .RuleFor(x => x.LastName, y => y.Person.LastName)
                .RuleFor(x => x.DOB, y => y.Person.DateOfBirth)
                .RuleFor(x => x.Bio, y => y.Person.Address.Suite + ": " + y.Lorem.Paragraph());
        }
    }
}
