using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models.ViewModels;

namespace ToDoList.Controllers
{
    public class GenericViewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenericViewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("TODO/toDosByUser/{name}")]
        public IActionResult toDosByUser(string name)
        {
            var user = _context.UserDatas.FirstOrDefault(p => p.FirstName.ToLower() == name.ToLower());
            if(user == null) return NotFound("Nije pronađen korisnik s tim imenom");

            var tasks = _context.User_ToDo_Relations.Include(p => p.ToDo)
                                                    .ThenInclude(p => p.Topic)
                                                    .Where(p => p.UserId == user.Id)
                                                    .OrderByDescending(p => p.ToDo.CreatedDate)
                                                    .Select(p => p.ToDo)
                                                    .ToList();


            return View(new UserTasksVM() { User = user, ToDos = tasks});
        }

        [HttpGet("TODO/Topics")]
        public IActionResult Topics()
        {
            return View(_context.Topics.Include(p => p.ToDos));
        }

        [HttpGet("TODO/UserData")]
        public IActionResult UsersWithData()
        {
            return View(_context.UserDatas.Include(p => p.PersonalData));
        }

        [HttpGet("TODO/CommentsByToDo")]
        public IActionResult CommentsByToDo()
        {
            return View(_context.ToDos.Include(p => p.Comments).ThenInclude(p => p.User));
        }
    }
}
