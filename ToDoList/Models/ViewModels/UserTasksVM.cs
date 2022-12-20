using ToDoList.Models.Database;

namespace ToDoList.Models.ViewModels
{
    public class UserTasksVM
    {
        public UserData User { get; set; }
        public List<ToDo> ToDos { get; set; }
    }
}
