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
        public DateTime CompletedDate  { get; set; }

        [Required]
        [Display(Name = "Tema")]
        public int TopicID { get; set; }

        [Display(Name = "Tema")]
        public Topic Topic { get; set; }
    }
}
