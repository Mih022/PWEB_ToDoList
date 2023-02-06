using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models.Database;

namespace ToDoList.Controllers
{
    public class UserDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserDatas.Include(u => u.PersonalData);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserDatas == null)
            {
                return NotFound();
            }

            var userData = await _context.UserDatas
                .Include(u => u.PersonalData)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // GET: UserDatas/Create
        public IActionResult Create()
        {
            var takenPDs = _context.UserDatas.Where(p => p.PersonalDataID != null)
                                            .Select(p => p.PersonalDataID)
                                            .ToList();
            var validPDs = _context.Set<PersonalData>().Where(p => !takenPDs.Contains(p.Id));
            ViewData["PersonalDataID"] = new SelectList(validPDs, "Id", "Id");
            return View();
        }

        // POST: UserDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PersonalDataID")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonalDataID"] = new SelectList(_context.Set<PersonalData>(), "Id", "Id", userData.PersonalDataID);
            return View(userData);
        }

        // GET: UserDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserDatas == null)
            {
                return NotFound();
            }

            var userData = await _context.UserDatas.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }
            var takenPDs = _context.UserDatas.Where(p => p.PersonalDataID != null)
                                .Select(p => p.PersonalDataID)
                                .ToList();
            var validPDs = _context.Set<PersonalData>().Where(p => !takenPDs.Contains(p.Id) || 
                                                            p.Id == userData.PersonalDataID);
            ViewData["PersonalDataID"] = new SelectList(validPDs, "Id", "Email");
            return View(userData);
        }

        // POST: UserDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,PersonalDataID")] UserData userData)
        {
            if (id != userData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDataExists(userData.Id))
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
            ViewData["PersonalDataID"] = new SelectList(_context.Set<PersonalData>(), "Id", "Id", userData.PersonalDataID);
            return View(userData);
        }

        // GET: UserDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserDatas == null)
            {
                return NotFound();
            }

            var userData = await _context.UserDatas
                .Include(u => u.PersonalData)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // POST: UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserDatas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserData'  is null.");
            }
            var userData = await _context.UserDatas.FindAsync(id);
            if (userData != null)
            {
                _context.UserDatas.Remove(userData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDataExists(string id)
        {
          return _context.UserDatas.Any(e => e.Id == id);
        }
    }
}
