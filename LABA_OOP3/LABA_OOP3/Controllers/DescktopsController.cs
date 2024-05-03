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
    public class DescktopsController : Controller
    {
        private readonly Abd _context;

        public DescktopsController(Abd context)
        {
            _context = context;
        }

        // GET: Descktops
        public async Task<IActionResult> Index()
        {
            var abd = _context.Descktops.Include(d => d.Human);
            return View(await abd.ToListAsync());
        }

        // GET: Descktops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descktop = await _context.Descktops
                .Include(d => d.Human)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (descktop == null)
            {
                return NotFound();
            }

            return View(descktop);
        }

        // GET: Descktops/Create
        public IActionResult Create()
        {
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID");
            return View();
        }

        // POST: Descktops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,HumanID")] Descktop descktop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descktop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID", descktop.HumanID);
            return View(descktop);
        }

        // GET: Descktops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descktop = await _context.Descktops.FindAsync(id);
            if (descktop == null)
            {
                return NotFound();
            }
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID", descktop.HumanID);
            return View(descktop);
        }

        // POST: Descktops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,HumanID")] Descktop descktop)
        {
            if (id != descktop.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descktop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescktopExists(descktop.ID))
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
            ViewData["HumanID"] = new SelectList(_context.Humans, "ID", "ID", descktop.HumanID);
            return View(descktop);
        }

        // GET: Descktops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descktop = await _context.Descktops
                .Include(d => d.Human)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (descktop == null)
            {
                return NotFound();
            }

            return View(descktop);
        }

        // POST: Descktops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descktop = await _context.Descktops.FindAsync(id);
            if (descktop != null)
            {
                _context.Descktops.Remove(descktop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescktopExists(int id)
        {
            return _context.Descktops.Any(e => e.ID == id);
        }
    }
}
