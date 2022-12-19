using Microsoft.AspNetCore.Identity;

namespace ToDoList.Models.Database
{
    public class UserData : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}
