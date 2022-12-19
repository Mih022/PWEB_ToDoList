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
        public PersonalData PersonalData { get; set; }

    }
}
