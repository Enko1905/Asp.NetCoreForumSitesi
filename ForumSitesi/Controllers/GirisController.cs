using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Controllers
{
    public class GirisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
