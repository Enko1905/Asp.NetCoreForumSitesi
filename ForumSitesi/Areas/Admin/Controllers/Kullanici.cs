using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumSitesi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class Kullanici : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public Kullanici(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public  IActionResult Index()
        {
            var kullancilar = GetUsersAsync();
            return View(kullancilar);
        }
        public async Task<List<AppUser>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();  
        }
    }
}
