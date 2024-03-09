using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;

namespace ForumSitesi.Controllers
{
    public class KonuController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public KonuController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        PostManager _postManager = new PostManager(new EfPostDal());
        TopicManager _topicManager = new TopicManager(new EfTopicDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        
        [AllowAnonymous]
        public IActionResult Index(string? title, int id)
        {
            bool giris = false;
            string userId = _userManager.GetUserId(User);

            var GoruntulemeSayisi = _topicManager.TGetById(id);
            GoruntulemeSayisi.TopicView += 1;
            _topicManager.TUpdate(GoruntulemeSayisi);


            if (userId != null)
            {
                giris = true;
            }
            ViewBag.LoginUserId = userId;
            var topics = _topicManager.GetTopicListWithCategory();
            if (id!=null)
            {
                var result = new
                {
                    Gettopic = _topicManager.GetTopicListWithCategory().Where(x => x.TopicID == id).FirstOrDefault(),
                    MostVotedTopic = _topicManager.GetTopicListWithCategory().OrderByDescending(x => x.TopicID).ThenByDescending(x => x.TopicVotes).ToList(),
                    GetUserId = userId,
                    UserGiris = giris,
                    Getpost = _postManager.GetPostListWidthTopicAndUser().Where(x => x.TopicID == id).ToList(),
                    GetPostCount = _postManager.GetPostListWidthTopicAndUser().Where(x => x.TopicID == id).Count()
                };
                return View(result);
            }

            else
            {
                return RedirectToAction("Index", "default");
            }
        }

        [HttpGet]
        public ActionResult YeniKonu()
        {
            string userId = _userManager.GetUserId(User);
            List<SelectListItem> categorys = (from x in _categoryManager.GetAll()
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }).ToList();
            ViewBag.category = categorys;
            if (userId != null)
            {
                var result = new
                {
                    GetUserId = userId
                };

                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "default");
            }

        }
        [HttpPost]
        public ActionResult YeniKonu(Topic t, Post p)
        {
            if (t.AppUserId != null)
            {
                try
                {
                    t.TopicVotes = 0;
                    _topicManager.TInsert(t);
                    var sonKonu = _topicManager.GetAll().OrderByDescending(x => x.TopicID).Take(1).FirstOrDefault();
                    p.TopicID = sonKonu.TopicID;
                    _postManager.TInsert(p);
                    return RedirectToAction("Index", "konu", new { id = p.TopicID });
                }
                catch
                {
                    return RedirectToAction("Index", "default");

                }

            }
            else
            {
                return RedirectToAction("Index", "default");

            }
        }
        [HttpPost]
        public IActionResult Message(Post p)
        {
            _postManager.TInsert(p);

            return RedirectToAction("Index", "konu", new { id = p.TopicID });
        }

    }
}
