using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class KonuController : Controller
    {
        TopicManager _topicManager = new TopicManager(new EfTopicDal());
        public IActionResult Index()
        {
            var result = _topicManager.GetTopicListWithCategoryAndUser().ToList();
            return View(result);
        }
        public IActionResult EngellenenKonular()
        {
            var result = _topicManager.GetTopicListWithCategoryAndUser().Where(x=>x.TopicStatus==1).ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult KonuGuncelle(int id){
            if(id==null) RedirectToAction("Index");
           var veri = _topicManager.TGetById(id);
            return View(veri);
        }
        [HttpPost]
        public IActionResult KonuGuncelle(Topic t){
            var veri = _topicManager.TGetById(t.TopicID);
            veri.TopicTitle = t.TopicTitle;
            _topicManager.TUpdate(veri);
            return RedirectToAction("Index");
        }

        [HttpGet]
         public IActionResult KonuDurum(int id){
            var veri = _topicManager.TGetById(id);
            if(veri.TopicStatus== 0)
            {
                veri.TopicStatus = 1;
            }
            else if(veri.TopicStatus== 1)
            {
                veri.TopicStatus = 0;
            }
            _topicManager.TUpdate(veri);
            return RedirectToAction("Index");
        }
    }
}
