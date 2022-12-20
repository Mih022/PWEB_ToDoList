using Bogus;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Database
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tekst")]
        public string Text { get; set; }

        public int ToDoID { get; set; }
        public ToDo? ToDo { get; set; }

        public int UserID { get; set; }
        public UserData? User { get; set; }


        public static Faker<Comment> GetFaker(List<int> userIDs, List<int> toDoIDs)
        {
            return new Faker<Comment>("hr")
                .RuleFor(p => p.Text, x => $"{x.Hacker.Phrase()}")
                .RuleFor(p => p.ToDoID, x => x.PickRandom(toDoIDs))
                .RuleFor(p => p.UserID, x => x.PickRandom(userIDs));
        }
    }
}
