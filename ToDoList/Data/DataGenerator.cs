using Bogus;
using Microsoft.AspNetCore.Identity;
using ToDoList.Models.Database;

namespace ToDoList.Data
{
    public class DataGenerator
    {
        public static void Generate(ApplicationDbContext context, UserManager<UserData> userManager)
        {
            const int userCount = 2;
            const int toDoCount = 100;
            const int topicCount = 5;
            const int usToDoRelationCount = 150;
            const int commentCount = 200;

            //skip if already generated
            if (context.UserDatas.Count() != 0) return;

            var userFaker = UserData.GetFaker();
            var users = userFaker.Generate(userCount);
            foreach (var userData in users)
            {
                //var user = CreateUser();
                //user.FirstName = userData.FirstName;
                //user.LastName = userData.LastName;
                //user.DOB = userData.DOB;
                //user.Bio = userData.Bio;
                //var a = userManager.SetUserNameAsync(user, userData.UserName);
                var b = userManager.CreateAsync(userData, "password");
            }
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

            var commentFaker = Comment.GetFaker(userIDs, todoIDs);
            context.Comments.AddRange(commentFaker.Generate(commentCount));
            context.SaveChanges();
        }

        private static UserData CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UserData>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
