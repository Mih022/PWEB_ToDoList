using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models.Database;

namespace ToDoList.Controllers.App
{
    public class App_CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserData> _userManager;

        public App_CommentsController(ApplicationDbContext context, UserManager<UserData> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comments/Create
        public async Task<IActionResult> Create(int? todoID)
        {
            if (todoID == null) return NotFound();
            var comment = new Comment();
            comment.ToDoID = todoID.Value;

            var user = await _userManager.GetUserAsync(User);
            comment.UserID = user.Id;

            return View(comment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,ToDoID,UserID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CommentDate = DateTime.Now;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "App_ToDoes", new {id = comment.ToDoID});
            }
            return View(comment);
        }
    }
}
