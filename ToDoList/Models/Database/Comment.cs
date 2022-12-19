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
        public ToDo ToDo { get; set; }
    }
}
