using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumSitesi.Controllers
{
    public class defaultController : Controller
    {

        TopicManager _topicManager = new TopicManager(new EfTopicDal());
        
        public IActionResult Index()
        {
            var topics = _topicManager.GetTopicListWithCategory();
            var users = _topicManager.GetPostListWithUserAsync();
            var result = new
            {
                MostVotedTopic = topics.OrderByDescending(x => x.TopicVotes).ThenByDescending(x => x.TopicID).ToList().Take(10),
                NewestTopic = topics.OrderByDescending(x => x.TopicID).ToList().Take(20),
                category = topics.ToList(),
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
            var result = _postManager.GetPostListWidthTopicAndUser().OrderByDescending(x=>x.PostID).ToList();
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
