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
    public class game_characterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public game_characterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: game_character
        public async Task<IActionResult> Index()
        {
            return View(await _context.game_character.ToListAsync());
        }

        // GET: game_character/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_character = await _context.game_character
                .FirstOrDefaultAsync(m => m.ID == id);
            if (game_character == null)
            {
                return NotFound();
            }

            return View(game_character);
        }

        // GET: game_character/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: game_character/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nickname,max_HP,HP,armor_ID,weapon_ID,potions_ID")] game_character game_character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game_character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game_character);
        }

        // GET: game_character/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_character = await _context.game_character.FindAsync(id);
            if (game_character == null)
            {
                return NotFound();
            }
            return View(game_character);
        }

        // POST: game_character/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nickname,max_HP,HP,armor_ID,weapon_ID,potions_ID")] game_character game_character)
        {
            if (id != game_character.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game_character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!game_characterExists(game_character.ID))
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
            return View(game_character);
        }

        // GET: game_character/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_character = await _context.game_character
                .FirstOrDefaultAsync(m => m.ID == id);
            if (game_character == null)
            {
                return NotFound();
            }

            return View(game_character);
        }

        // POST: game_character/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game_character = await _context.game_character.FindAsync(id);
            if (game_character != null)
            {
                _context.game_character.Remove(game_character);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool game_characterExists(int id)
        {
            return _context.game_character.Any(e => e.ID == id);
        }
    }
}
