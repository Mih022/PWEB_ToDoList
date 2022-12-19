namespace ToDoList.Models.Database
{
    public class User_ToDo_Relation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserData User { get; set; }
        public int ToDoID { get; set; }
        public ToDo ToDo { get; set; }
    }
}
