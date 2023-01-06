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
    public class EvenementsController : Controller
    {
        private readonly BordspelhubContext _context;

        public EvenementsController(BordspelhubContext context)
        {
            _context = context;
        }

        // GET: Evenements
        public async Task<IActionResult> Index()
        {
              return _context.Evenementen != null ? 
                          View(await _context.Evenementen.ToListAsync()) :
                          Problem("Entity set 'BordspelhubContext.Evenementen'  is null.");
        }

        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evenementen == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenementen
                .FirstOrDefaultAsync(m => m.EvenementId == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // GET: Evenements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvenementId,EvenementNaam,Locatie,EvenementDatum,URL,Creator,Beschrijving")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evenement);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evenementen == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenementen.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            return View(evenement);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvenementId,EvenementNaam,Locatie,EvenementDatum,URL,Creator,Beschrijving")] Evenement evenement)
        {
            if (id != evenement.EvenementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementExists(evenement.EvenementId))
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
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evenementen == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenementen
                .FirstOrDefaultAsync(m => m.EvenementId == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evenementen == null)
            {
                return Problem("Entity set 'BordspelhubContext.Evenementen'  is null.");
            }
            var evenement = await _context.Evenementen.FindAsync(id);
            if (evenement != null)
            {
                _context.Evenementen.Remove(evenement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementExists(int id)
        {
          return (_context.Evenementen?.Any(e => e.EvenementId == id)).GetValueOrDefault();
        }
    }
}
