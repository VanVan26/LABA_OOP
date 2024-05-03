using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LABA_OOP3.Data;
using LABA_OOP3.Models;

namespace LABA_OOP3.Controllers
{
    public class HumanToClassroomsController : Controller
    {
        private readonly Abd _context;

        public HumanToClassroomsController(Abd context)
        {
            _context = context;
        }

        // GET: HumanToClassrooms
        public async Task<IActionResult> Index()
        {
            var abd = _context.HumanToClassrooms.Include(h => h.Classroom).Include(h => h.Human);
            return View(await abd.ToListAsync());
        }

        // GET: HumanToClassrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humanToClassroom = await _context.HumanToClassrooms
                .Include(h => h.Classroom)
                .Include(h => h.Human)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (humanToClassroom == null)
            {
                return NotFound();
            }

            return View(humanToClassroom);
        }

        // GET: HumanToClassrooms/Create
        public IActionResult Create()
        {
            ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "Id", "Id");
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID");
            return View();
        }

        // POST: HumanToClassrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HumanID,ClassroomID")] HumanToClassroom humanToClassroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(humanToClassroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "Id", "Id", humanToClassroom.ClassroomID);
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID", humanToClassroom.HumanID);
            return View(humanToClassroom);
        }

        // GET: HumanToClassrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humanToClassroom = await _context.HumanToClassrooms.FindAsync(id);
            if (humanToClassroom == null)
            {
                return NotFound();
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "Id", "Id", humanToClassroom.ClassroomID);
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID", humanToClassroom.HumanID);
            return View(humanToClassroom);
        }

        // POST: HumanToClassrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HumanID,ClassroomID")] HumanToClassroom humanToClassroom)
        {
            if (id != humanToClassroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(humanToClassroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumanToClassroomExists(humanToClassroom.Id))
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
            ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "Id", "Id", humanToClassroom.ClassroomID);
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID", humanToClassroom.HumanID);
            return View(humanToClassroom);
        }

        // GET: HumanToClassrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humanToClassroom = await _context.HumanToClassrooms
                .Include(h => h.Classroom)
                .Include(h => h.Human)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (humanToClassroom == null)
            {
                return NotFound();
            }

            return View(humanToClassroom);
        }

        // POST: HumanToClassrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var humanToClassroom = await _context.HumanToClassrooms.FindAsync(id);
            if (humanToClassroom != null)
            {
                _context.HumanToClassrooms.Remove(humanToClassroom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HumanToClassroomExists(int id)
        {
            return _context.HumanToClassrooms.Any(e => e.Id == id);
        }
    }
}
