using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Components
{
    public class CategoryTopicViewComponent:ViewComponent
    {
        TopicManager _topicManager = new TopicManager(new EfTopicDal());
        public string Invoke(int categoriesid)
        {
            return _topicManager.GetAll().Where(x=>x.CategoryID== categoriesid).Count().ToString();
        }
    }
}
