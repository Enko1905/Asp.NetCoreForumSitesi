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
        PostManager _postManager = new PostManager(new EfPostDal());

        public IActionResult Index([FromRoute(Name = "id")] string? kategori,int? id , string ? ara)
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
            var users = _userManager.Users.Count();
            var topics = _topicManager.GetTopicListWithCategory().Where(x=>x.TopicStatus==0);
            var topicVotes = topics.OrderByDescending(x => x.TopicVotes).ThenByDescending(x => x.TopicID).ToList().Take(10);
            var newestTopics = topics.OrderByDescending(x => x.TopicID).ToList().Take(20);
            if(id != null)
            {
                newestTopics = topics.Where(x => x.CategoryID == id).OrderByDescending(x => x.TopicID).Take(20).ToList();
            }
            if (!string.IsNullOrEmpty(ara)){
                ara = ara.ToLower().Trim();
                newestTopics = topics.Where(x => x.TopicTitle.ToLower().Trim().Contains(ara)).OrderByDescending(x => x.TopicID).ToList();

            }
            var category = _category.GetAll();
            var postCount = _postManager.GetAll().Count();

            var result = new
            {
                MostVotedTopic = topicVotes,
                NewestTopic = newestTopics,
                category = category.ToList(),
                UserGiris = giris,
                istatistik = topics.Count(),
                userSayisi = users,
                postSayisi = postCount,
                //sonUser =   users.GetAwaiter().GetResult().OrderByDescending(x => x.TopicID).Take(1).SingleOrDefault(),
                //user = users
            };


            return View(result);
        }

        public IActionResult SonGonderiler()
        {
            var result = _postManager.GetPostListWidthTopicAndUser().OrderByDescending(x => x.PostID).ToList();
            return View(result);
        }

        public IActionResult Kategoriler()
        {
            var result = _topicManager.GetTopicListWithCategory().Where(x => x.TopicStatus == 0).ToList();
            return View(result);
        }
        public IActionResult test()
        {
            var topic = _topicManager.GetPostListWithUserAsync().GetAwaiter().GetResult().Take(25);
            return View(topic);
        }
    }
}
