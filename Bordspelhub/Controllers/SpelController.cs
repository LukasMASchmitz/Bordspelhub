using Bordspelhub.Data;
using Bordspelhub.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bordspelhub.Controllers
{
    public class SpelController : Controller
    {

        private BordspelhubContext context { get; }
        

        public SpelController(BordspelhubContext context)
        {
            this.context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Spel spel)
        {
            context.Add(spel);
            context.SaveChanges();
            ViewBag.message = "De data is opgeslagen";
            return View();
        }

    }
}
