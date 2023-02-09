using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models.Database;

namespace ToDoList.Controllers.App
{
    public class App_ToDoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserData> _userManager;

        public App_ToDoesController(ApplicationDbContext context, UserManager<UserData> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public class DetailsViewModel
        {
            public ToDo ToDo { get; set; }
            public IEnumerable<Comment> Comments { get; set; }
        }

        // GET: AppToDoes
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var todos = _context.User_ToDo_Relations.Include(p => p.ToDo)
                                                    .ThenInclude(p => p.Topic)
                                                    .Where(p => p.UserId == user.Id)
                                                    .OrderBy(p => p.ToDo.CompletedDate)
                                                    .Select(p => p.ToDo);
            return View(await todos.ToListAsync());
        }

        // GET: AppToDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .Include(t => t.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (toDo == null) return NotFound();

            var comments = _context.Comments.Include(p => p.User)
                                            .Where(p => p.ToDoID == toDo.Id)
                                            .OrderBy(p => p.CommentDate)
                                            .ToList();
            if (toDo == null)
            {
                return NotFound();
            }

            return View(new DetailsViewModel() { ToDo = toDo, Comments = comments});
        }

        // GET: AppToDoes/Create
        public IActionResult Create()
        {
            ViewData["TopicID"] = new SelectList(_context.Topics, "Id", "Name");
            return View();
        }

        // POST: AppToDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreatedDate,CompletedDate,TopicID")] ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                ViewData["TopicID"] = new SelectList(_context.Topics, "Id", "Name", toDo.TopicID);
                return View(toDo);
            }

            using var transaction = _context.Database.BeginTransaction();

            var user = await _userManager.GetUserAsync(User);

            toDo.CreatedDate = DateTime.Today;
            _context.Add(toDo);
            await _context.SaveChangesAsync();

            var relation = new User_ToDo_Relation()
            {
                UserId = user.Id,
                ToDoID = toDo.Id
            };
            _context.User_ToDo_Relations.Add(relation);
            await _context.SaveChangesAsync();

            transaction.Commit();

            return RedirectToAction(nameof(Index));
        }

        // GET: AppToDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            ViewData["TopicID"] = new SelectList(_context.Topics, "Id", "Name", toDo.TopicID);
            return View(toDo);
        }

        // POST: AppToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedDate,CompletedDate,TopicID")] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldTodo = _context.ToDos.AsNoTracking().FirstOrDefault(p => p.Id == id);
                    toDo.CreatedDate = oldTodo.CreatedDate;
                    toDo.CompletedDate = oldTodo.CompletedDate;
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TopicID"] = new SelectList(_context.Topics, "Id", "Name", toDo.TopicID);
            return View(toDo);
        }

        // GET: AppToDoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .Include(t => t.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: AppToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ToDos'  is null.");
            }
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: AppToDoes/Resolve/5
        public async Task<IActionResult> Resolve(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            toDo.CompletedDate = DateTime.Now;
            _context.Update(toDo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new {id = id});
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
