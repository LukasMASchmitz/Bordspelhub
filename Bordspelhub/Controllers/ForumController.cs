using Bordspelhub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bordspelhub.Controllers
{
    
    public class ForumController : Controller
    {
        private readonly BordspelhubContext _context;

        public ForumController(BordspelhubContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Forum(int id)
        {
            var forums = from f in _context.Forums
                             join c in _context.Comments on f.ForumId equals c.ForumId
                             where f.ForumId == id
                             select new { f.Titel, f.Owner, f.Onderwerp, c.Commenter, c.CommentText };

            return View(await forums.ToListAsync());
        }

       
    }
}
