using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace ToDoList.Models.Database
{
    [Index(nameof(PersonalDataID))]
    public class UserData
    {
        public int Id { get; set; }

        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

        
        public int PersonalDataID { get; set; } // 1 to 1 polje zbog indexa
        public PersonalData? PersonalData { get; set; }


        public static Faker<UserData> GetFaker()
        {
            return new Faker<UserData>("hr")
                .RuleFor(x => x.FirstName, y => y.Person.FirstName)
                .RuleFor(x => x.LastName, y => y.Person.LastName)
                .RuleFor(x => x.PersonalData, y => new PersonalData()
                {
                    Email = y.Person.Email,
                    PhoneNumber = y.Person.Phone,
                    DOB = y.Person.DateOfBirth,
                    Bio = y.Person.Address.Suite + ": " + y.Lorem.Paragraph(),
                });
        }
    }
}
