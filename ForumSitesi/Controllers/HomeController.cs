using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ForumSitesi.Controllers
{
    public class HomeController : Controller
    {

        PostManager postManager = new PostManager(new EfPostDal());
        public IEnumerable<Post> Index()
        {
            var result = postManager.GetAll();
            return result.ToList();
        }
    }
}
