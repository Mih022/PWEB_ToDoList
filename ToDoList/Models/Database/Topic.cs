using Bogus;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
//using System.Text.Json.Serialization;

namespace ToDoList.Models.Database
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Ime")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<ToDo>? ToDos { get; set; }

        public static Faker<Topic> GetFaker()
        {
            return new Faker<Topic>("hr")
                .RuleFor(p => p.Name, x => x.Commerce.Department());
        }
    }
}
