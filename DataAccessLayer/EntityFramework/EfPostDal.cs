using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPostDal : GenericRepository<Post>, IPostDal
    {
        public List<Post> GetPostListWidthTopicAndUser()
        {
            using (var c = new RepositoryContext())
            {
                return c.Posts
                    .Include(t => t.Topic)
                    .Include(u => u.AppUser)
                    .ToList();
            }
        }
    }
}
