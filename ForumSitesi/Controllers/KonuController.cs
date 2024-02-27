using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Controllers
{
    public class KonuController : Controller
    {
        PostManager _postManager = new PostManager(new EfPostDal());
        TopicManager _topicManager = new TopicManager(new EfTopicDal());


        public IActionResult Index(int? id)
        {
            var topics = _topicManager.GetTopicListWithCategory();
            if (id.HasValue)
            {
                var result = new
                {
                    Gettopic = _topicManager.GetTopicListWithCategory().Where(x => x.TopicID == id).FirstOrDefault(),
                    MostVotedTopic = _topicManager.GetTopicListWithCategory().OrderByDescending(x=>x.TopicID).ThenByDescending(x=>x.TopicVotes).ToList(),

                    Getpost = _postManager.GetPostListWidthTopicAndUser().Where(x => x.TopicID == id).ToList(),
                    GetPostCount = _postManager.GetPostListWidthTopicAndUser().Where(x => x.TopicID == id).Count()
                };
                return View(result);
            }

            else
            {
                return RedirectToAction("Index","default");
            }
        }
    }
}
