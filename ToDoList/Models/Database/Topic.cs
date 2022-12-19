using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Database
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Ime")]
        public string Name { get; set; }
    }
}
