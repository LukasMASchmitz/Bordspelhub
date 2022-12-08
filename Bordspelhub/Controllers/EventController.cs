using Microsoft.AspNetCore.Mvc;

namespace Bordspelhub.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
