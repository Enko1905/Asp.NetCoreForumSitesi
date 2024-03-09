using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumSitesi.Controllers
{
    [AllowAnonymous]
    public class defaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public defaultController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        TopicManager _topicManager = new TopicManager(new EfTopicDal());
        CategoryManager _category = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            bool giris = false;

            string UserId = _userManager.GetUserId(User);
            if (UserId != null)
            {
                giris = true;
            }
            else
            {
                giris = false;
            }

            var topics = _topicManager.GetTopicListWithCategory();
            var users = _topicManager.GetPostListWithUserAsync();
            var category = _category.GetAll();
            var result = new
            {
                MostVotedTopic = topics.OrderByDescending(x => x.TopicVotes).ThenByDescending(x => x.TopicID).ToList().Take(10),
                NewestTopic = topics.OrderByDescending(x => x.TopicID).ToList().Take(20),
                category = category.ToList(),
                UserGiris = giris,
                istatistik = topics.Count(),
                userSayisi = users.GetAwaiter().GetResult().Count(),
                //sonUser =   users.GetAwaiter().GetResult().OrderByDescending(x => x.TopicID).Take(1).SingleOrDefault(),
                //user = users
            };

            return View(result);
        }

        PostManager _postManager = new PostManager(new EfPostDal());
        public IActionResult SonGonderiler()
        {
            var result = _postManager.GetPostListWidthTopicAndUser().OrderByDescending(x => x.PostID).ToList();
            return View(result);
        }

        public IActionResult Kategoriler()
        {
            var result = _topicManager.GetTopicListWithCategory().ToList();
            return View(result);
        }
        public IActionResult test()
        {
            var topic = _topicManager.GetPostListWithUserAsync().GetAwaiter().GetResult().Take(25);
            return View(topic);
        }
    }
}
