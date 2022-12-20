using Bogus;
using ToDoList.Models.Database;

namespace ToDoList.Data
{
    public class DataGenerator
    {
        public static void Generate(ApplicationDbContext context)
        {
            const int userCount = 10;
            const int toDoCount = 100;
            const int topicCount = 5;
            const int usToDoRelationCount = 150;
            const int commentCount = 200;

            //skip if already generated
            if (context.PersonalDatas.Count() != 0) return;

            var userFaker = UserData.GetFaker();
            context.UserDatas.AddRange(userFaker.Generate(userCount));
            context.SaveChanges();

            var topicFaker = Topic.GetFaker();
            context.Topics.AddRange(topicFaker.Generate(topicCount));
            context.SaveChanges();

            var topicIDs = context.Topics.Select(p => p.Id).ToList();
            var toDoFaker = ToDo.GetFaker(topicIDs);
            context.ToDos.AddRange(toDoFaker.Generate(toDoCount));
            context.SaveChanges();

            var userIDs = context.UserDatas.Select(p => p.Id).ToList();
            var todoIDs = context.ToDos.Select(p => p.Id).ToList();
            var relationFaker = User_ToDo_Relation.GetFaker(userIDs, todoIDs);
            context.User_ToDo_Relations.AddRange(relationFaker.Generate(usToDoRelationCount));

            var commentFaker = Comment.GetFaker(userIDs);
            context.Comments.AddRange(commentFaker.Generate(commentCount));
            context.SaveChanges();
        }
    }
}
