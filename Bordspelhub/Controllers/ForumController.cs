using Bordspelhub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bordspelhub.Controllers
{
    public class ForumController : Controller
    {
        private readonly BordspelhubContext _context;

        public ForumController(BordspelhubContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Forum(int id)
        {
            var forums = from f in _context.Forums
                             join c in _context.Comments on f.ForumId equals c.Forum.ForumId
                             where f.ForumId == id
                             select new { f.Titel, f.Onderwerp, Gebruiker, c.CommentText };

            return View(await forums.ToListAsync());
        }
    }
}
