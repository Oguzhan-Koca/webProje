using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
