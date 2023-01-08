using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bordspelhub.Data;
using Bordspelhub.Models;

namespace Bordspelhub.Controllers
{
    public class SpelsController : Controller
    {
        private readonly BordspelhubContext _context;

        public SpelsController(BordspelhubContext context)
        {
            _context = context;
        }

        // GET: Spels
        public async Task<IActionResult> Index()
        {
              return _context.Spellen != null ? 
                          View(await _context.Spellen.ToListAsync()) :
                          Problem("Entity set 'BordspelhubContext.Spellen'  is null.");
        }

        // GET: Spels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spellen == null)
            {
                return NotFound();
            }

            var spel = await _context.Spellen
                .FirstOrDefaultAsync(m => m.SpelId == id);
            if (spel == null)
            {
                return NotFound();
            }

            return View(spel);
        }

        // GET: Spels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpelId,SpelNaam,Gebruiker,Categorie,Pegi,Beschrijving")] Spel spel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spel);
        }

        // GET: Spels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spellen == null)
            {
                return NotFound();
            }

            var spel = await _context.Spellen.FindAsync(id);
            if (spel == null)
            {
                return NotFound();
            }
            return View(spel);
        }

        // POST: Spels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpelId,SpelNaam,Gebruiker,Categorie,Pegi,Beschrijving")] Spel spel)
        {
            if (id != spel.SpelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpelExists(spel.SpelId))
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
            return View(spel);
        }

        // GET: Spels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spellen == null)
            {
                return NotFound();
            }

            var spel = await _context.Spellen
                .FirstOrDefaultAsync(m => m.SpelId == id);
            if (spel == null)
            {
                return NotFound();
            }

            return View(spel);
        }

        // POST: Spels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spellen == null)
            {
                return Problem("Entity set 'BordspelhubContext.Spellen'  is null.");
            }
            var spel = await _context.Spellen.FindAsync(id);
            if (spel != null)
            {
                _context.Spellen.Remove(spel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpelExists(int id)
        {
          return (_context.Spellen?.Any(e => e.SpelId == id)).GetValueOrDefault();
        }
    }
}
