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
    public class ForaController : ControllerBase
    {
        private readonly BordspelhubContext _context;

        public ForaController(BordspelhubContext context)
        {
            _context = context;
        }

        // GET: api/Fora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forum>>> GetForums()
        {
          if (_context.Forums == null)
          {
              return NotFound();
          }
            return await _context.Forums.ToListAsync();
        }

        // GET: api/Fora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Forum>> GetForum(int id)
        {
          if (_context.Forums == null)
          {
              return NotFound();
          }
            var forum = await _context.Forums.FindAsync(id);

            if (forum == null)
            {
                return NotFound();
            }

            return forum;
        }

        // PUT: api/Fora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForum(int id, Forum forum)
        {
            if (id != forum.ForumId)
            {
                return BadRequest();
            }

            _context.Entry(forum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(id))
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

        // POST: api/Fora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Forum>> PostForum(Forum forum)
        {
          if (_context.Forums == null)
          {
              return Problem("Entity set 'BordspelhubContext.Forums'  is null.");
          }
            _context.Forums.Add(forum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForum", new { id = forum.ForumId }, forum);
        }

        // DELETE: api/Fora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForum(int id)
        {
            if (_context.Forums == null)
            {
                return NotFound();
            }
            var forum = await _context.Forums.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }

            _context.Forums.Remove(forum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumExists(int id)
        {
            return (_context.Forums?.Any(e => e.ForumId == id)).GetValueOrDefault();
        }
    }
}
