using EntityLayer.Concrete;
using ForumSitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Controllers
{
    public class KayitController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public KayitController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserViewModel model)
        {
            AppUser appUser = new AppUser()
            {
               Name = model.Name,
               UserName = model.UserName,
               Gender = model.Gender,
               Email =  model.Mail,

            };
            var result = await _userManager.CreateAsync(appUser, model.Password);

            return View(model);
        }
    }
}
