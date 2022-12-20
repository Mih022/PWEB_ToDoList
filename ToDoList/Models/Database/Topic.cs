using Bogus;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Database
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Ime")]
        public string Name { get; set; }

        public List<ToDo> ToDos { get; set; }

        public static Faker<Topic> GetFaker()
        {
            return new Faker<Topic>("hr")
                .RuleFor(p => p.Name, x => x.Commerce.Department());
        }
    }
}
