using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using ToDoList.Controllers.Admin;
using ToDoList.Controllers.App;
using ToDoList.Data;
using ToDoList.Models.Database;
using Xunit;

namespace ToDoList.Tests
{
    public class TopicControllerTests : TestBase
    {
        private readonly ApplicationDbContext _context;

        public TopicControllerTests(ApplicationDbContext context)
        {
            _context = context;
        }

        public override async Task Do_tests()
        {
            await Test_index_get();
            await Test_if_notfound_when_id_null();
            await Test_if_notfound_when_id_invalid();
            await Test_adding();
        }

        private async Task Test_index_get()
        {
            var topicController = new App_TopicsController(_context);

            var result = topicController.Index();

            Assert.IsType(typeof(ViewResult), result.Result);
        }

        private async Task Test_if_notfound_when_id_null()
        {
            var topicController = new App_TopicsController(_context);

            var result = topicController.Details(null);

            Assert.IsType(typeof(NotFoundResult), result.Result);
        }

        private async Task Test_if_notfound_when_id_invalid()
        {
            var topicController = new App_TopicsController(_context);

            var result = topicController.Details(-1);

            Assert.IsType(typeof(NotFoundResult), result.Result);
        }

        private async Task Test_adding()
        {
            var toRemove = _context.Topics.Where(p => p.Name == "TESTTESTTEST");
            _context.Topics.RemoveRange(toRemove);
            await _context.SaveChangesAsync();

            var topicController = new TopicsController(_context);
            var newTopic = new Topic() { Name = "TESTTESTTEST" };
            var result = await topicController.Create(newTopic);

            Assert.IsType(typeof(RedirectToActionResult), result);
            var createdTopic = _context.Topics.FirstOrDefault(p => p.Name == "TESTTESTTEST");

            Assert.NotEqual(null, createdTopic);
            _context.Remove(createdTopic);
            await _context.SaveChangesAsync();

        }
    }
}
