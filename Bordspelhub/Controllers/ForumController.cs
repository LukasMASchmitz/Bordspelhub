using Microsoft.AspNetCore.Mvc;

namespace Bordspelhub.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Forum()
        {
            return View();
        }
    }
}
