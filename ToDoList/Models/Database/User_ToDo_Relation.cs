using Bogus;

namespace ToDoList.Models.Database
{
    public class User_ToDo_Relation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserData? User { get; set; }
        public int ToDoID { get; set; }
        public ToDo? ToDo { get; set; }

        public static Faker<User_ToDo_Relation> GetFaker(List<int> userIDs, List<int> todoIDs)
        {
            return new Faker<User_ToDo_Relation>("hr")
                .RuleFor(p => p.UserId, x => x.PickRandom(userIDs))
                .RuleFor(p => p.ToDoID, x => x.PickRandom(todoIDs));
        }
    }
}
