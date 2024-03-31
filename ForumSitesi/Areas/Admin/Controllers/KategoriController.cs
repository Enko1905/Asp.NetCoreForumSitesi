using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class KategoriController : Controller
    {

        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var result = _categoryManager.GetAll();
            return View(result);
        }
        [HttpGet]
        public IActionResult YeniKategori()
        {
            return View();

        }
        [HttpPost]
        public IActionResult YeniKategori(Category c)
        {
            _categoryManager.TInsert(c);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult KategoriGuncelle(int id)
        {

            var result= _categoryManager.TGetById(id);

            return View(result);

        }
        [HttpPost]
        public IActionResult KategoriGuncelle(Category c)
        {

            _categoryManager.TUpdate(c);

            return RedirectToAction("Index");

        }
    }
}
