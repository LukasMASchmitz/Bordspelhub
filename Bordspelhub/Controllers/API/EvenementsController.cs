using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bordspelhub.Data;
using Bordspelhub.Models;

namespace Bordspelhub.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementsController : ControllerBase
    {
        private readonly BordspelhubContext _context;

        public EvenementsController(BordspelhubContext context)
        {
            _context = context;
        }

        // GET: api/Evenements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evenement>>> GetEvenementen()
        {
          if (_context.Evenementen == null)
          {
              return NotFound();
          }
            return await _context.Evenementen.ToListAsync();
        }

        // GET: api/Evenements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evenement>> GetEvenement(int id)
        {
          if (_context.Evenementen == null)
          {
              return NotFound();
          }
            var evenement = await _context.Evenementen.FindAsync(id);

            if (evenement == null)
            {
                return NotFound();
            }

            return evenement;
        }

        // PUT: api/Evenements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvenement(int id, Evenement evenement)
        {
            if (id != evenement.EvenementId)
            {
                return BadRequest();
            }

            _context.Entry(evenement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvenementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Evenements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evenement>> PostEvenement(Evenement evenement)
        {
          if (_context.Evenementen == null)
          {
              return Problem("Entity set 'BordspelhubContext.Evenementen'  is null.");
          }
            _context.Evenementen.Add(evenement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvenement", new { id = evenement.EvenementId }, evenement);
        }

        // DELETE: api/Evenements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvenement(int id)
        {
            if (_context.Evenementen == null)
            {
                return NotFound();
            }
            var evenement = await _context.Evenementen.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }

            _context.Evenementen.Remove(evenement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvenementExists(int id)
        {
            return (_context.Evenementen?.Any(e => e.EvenementId == id)).GetValueOrDefault();
        }
    }
}
