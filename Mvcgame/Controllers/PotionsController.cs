using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvcgame.Data;
using Mvcgame.Models;

namespace Mvcgame.Controllers
{
    public class PotionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PotionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Potions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Potions.ToListAsync());
        }

        // GET: Potions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potions = await _context.Potions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (potions == null)
            {
                return NotFound();
            }

            return View(potions);
        }

        // GET: Potions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Potions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,protection,damage,heal")] Potions potions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(potions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(potions);
        }

        // GET: Potions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potions = await _context.Potions.FindAsync(id);
            if (potions == null)
            {
                return NotFound();
            }
            return View(potions);
        }

        // POST: Potions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,protection,damage,heal")] Potions potions)
        {
            if (id != potions.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(potions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PotionsExists(potions.ID))
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
            return View(potions);
        }

        // GET: Potions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potions = await _context.Potions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (potions == null)
            {
                return NotFound();
            }

            return View(potions);
        }

        // POST: Potions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var potions = await _context.Potions.FindAsync(id);
            if (potions != null)
            {
                _context.Potions.Remove(potions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PotionsExists(int id)
        {
            return _context.Potions.Any(e => e.ID == id);
        }
    }
}
