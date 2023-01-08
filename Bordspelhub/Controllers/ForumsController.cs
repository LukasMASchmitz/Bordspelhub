using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bordspelhub.Data;
using Bordspelhub.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bordspelhub.Controllers
{
    public class ForumsController : Controller
    {
        private readonly BordspelhubContext _context;

        public ForumsController(BordspelhubContext context)
        {
            _context = context;
        }

        // GET: Forums
        public async Task<IActionResult> Index()
        {
              return _context.Forums != null ? 
                          View(await _context.Forums.ToListAsync()) :
                          Problem("Entity set 'BordspelhubContext.Forums'  is null.");
        }
        [Authorize]
        // GET: Forums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Forums == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .FirstOrDefaultAsync(m => m.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            } else
            {
                dynamic forumInfo = new ForumInfo();

                var forum1 = from f in _context.Forums
                            where f.ForumId == id
                            select f;

                var comments = from c in _context.Comments
                               where c.ForumId == id
                               select c;

                forumInfo.Forums = await forum1.ToListAsync();
                if (comments != null)
                {
                    forumInfo.Comments = await comments.ToListAsync();
                }
                return View(forumInfo);
            }
        }

        [Authorize]
        // GET: Forums/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Forums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForumId,Titel,Onderwerp,Owner")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forum);
        }
        [Authorize]
        // GET: Forums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Forums == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }
            return View(forum);
        }
        [Authorize]
        // POST: Forums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ForumId,Titel,Onderwerp,Owner")] Forum forum)
        {
            if (id != forum.ForumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumExists(forum.ForumId))
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
            return View(forum);
        }
        [Authorize]
        // GET: Forums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Forums == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .FirstOrDefaultAsync(m => m.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }
        [Authorize]
        // POST: Forums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Forums == null)
            {
                return Problem("Entity set 'BordspelhubContext.Forums'  is null.");
            }
            var forum = await _context.Forums.FindAsync(id);
            if (forum != null)
            {
                _context.Forums.Remove(forum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumExists(int id)
        {
          return (_context.Forums?.Any(e => e.ForumId == id)).GetValueOrDefault();
        }

        [Authorize]
        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([Bind("CommentId,CommentText,Commenter")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }
    }
}
