using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Controllers.App;
using ToDoList.Data;
using ToDoList.Models.Database;
using Xunit;

namespace ToDoList.Tests
{
    public class ToDoesControllerTests : TestBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserData> _userManager;

        public ToDoesControllerTests(ApplicationDbContext context, UserManager<UserData> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public override async Task Do_tests()
        {
            await Test_if_notfound_when_id_null();
            await Test_if_notfound_when_id_invalid();
        }

        private async Task Test_if_notfound_when_id_null()
        {
            var toDoController = new App_ToDoesController(_context, _userManager);

            var result = toDoController.Details(null);

            Assert.IsType(typeof(NotFoundResult), result.Result);
        }

        private async Task Test_if_notfound_when_id_invalid()
        {
            var toDoController = new App_ToDoesController(_context, _userManager);

            var result = toDoController.Details(-1);

            Assert.IsType(typeof(NotFoundResult), result.Result);
        }
    }
}
