using Bogus;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Database
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Naziv")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Datum kreiranja")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Datum zatvaranja")]
        public DateTime? CompletedDate  { get; set; }

        [Required]
        [Display(Name = "Tema")]
        public int TopicID { get; set; }

        [Display(Name = "Tema")]
        public Topic? Topic { get; set; }
        
        public List<Comment> Comments { get; set; }

        public static Faker<ToDo> GetFaker(List<int> topicIDs)
        {
            return new Faker<ToDo>("hr")
                .RuleFor(p => p.Name, x => $"{x.Hacker.Adjective()} {x.Commerce.Product()}")
                .RuleFor(p => p.Description, x => $"{x.Hacker.Adjective()} {x.Hacker.Noun()}:\n " +
                                  $"{x.Hacker.IngVerb()} {x.Hacker.Abbreviation()}")
                .RuleFor(p => p.CreatedDate, x => x.Date.Between(DateTime.Today.AddYears(-1), 
                                                                DateTime.Today.AddMonths(-1)))
                .RuleFor(p => p.CompletedDate, x => x.Date.Between(DateTime.Today.AddMonths(-1), 
                                                                    DateTime.Today)
                                                          .OrNull(x, 0.5f))
                .RuleFor(p => p.TopicID, x => x.PickRandom(topicIDs));
        }
    }
}
