using EntityLayer.Concrete;
using ForumSitesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Controllers
{
    [AllowAnonymous]

    public class GirisController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;



        public GirisController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ViewUserLoginModel model)
        {
            var result= await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
            if(result.Succeeded)
            {
                string UserId=_userManager.GetUserId(User);
                return RedirectToAction("Index","default");
            }
            else
            {
                //Error Hata Mesajı Yazılacak
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            UserLoginId.UserId = null;
            return RedirectToAction("Index", "Giris");
        }

    }
}
