using Microsoft.AspNetCore.Identity;
using ToDoList.Data;
using ToDoList.Models.Database;

namespace ToDoList.Tests
{
    public abstract class TestBase
    {
        public static async Task Do_all_tests(ApplicationDbContext context, UserManager<UserData> userManager)
        {
            var topics = new TopicControllerTests(context);
            await topics.Do_tests();

            var toDoes = new ToDoesControllerTests(context, userManager);
            await toDoes.Do_tests();
        }
        public abstract Task Do_tests();
    }
}
