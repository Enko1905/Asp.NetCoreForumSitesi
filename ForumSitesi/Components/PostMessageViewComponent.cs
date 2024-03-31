using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
namespace ForumSitesi.Components
{
    public class PostMessageViewComponent:ViewComponent
    {
        PostManager _postmangaer = new PostManager(new EfPostDal());
        public string Invoke(int topicid)
        {
            string veri = _postmangaer.GetAll().Where(x=>x.TopicID==topicid).Count().ToString();
            return veri;
        }
    }
}
