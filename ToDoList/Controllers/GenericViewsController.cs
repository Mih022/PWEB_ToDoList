using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;

namespace ToDoList.Controllers
{
    public class GenericViewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenericViewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("toDosByUser/{name}")]
        public IActionResult toDosByUser(string name)
        {
            var user = _context.UserDatas.FirstOrDefault(p => p.FirstName.ToLower() == name.ToLower());
            if(user == null) return NotFound("Nije pronađen korisnik s tim imenom");

            var tasks = _context.User_ToDo_Relations.Include(p => p.ToDo)
                                                    .ThenInclude(p => p.Topic)
                                                    .Where(p => p.UserId == user.Id)
                                                    .OrderByDescending(p => p.ToDo.CreatedDate)
                                                    .Select(p => p.ToDo);


            return View(tasks);
        }
    }
}
