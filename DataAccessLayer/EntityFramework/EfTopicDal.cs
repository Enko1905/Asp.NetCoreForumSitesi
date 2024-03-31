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
    public class EfTopicDal:GenericRepository<Topic>,ITopicDal
    {
        public async Task<List<Topic>> GetPostListWithUserAsync()
        {
            using (var c = new RepositoryContext())
            {
                return   c.Topics.Include(t => t.AppUser).ToList();
            }
        }

        public List<Topic> GetTopicListWithCategory()
        {
            using (var c = new RepositoryContext())
            {
                return c.Topics.Include(t => t.Category).ToList();  
            }
        }

        public List<Topic> GetTopicListWithCategoryAndUser()
        {
           using(var c = new RepositoryContext())
            {
                return c.Topics.Include(t => t.AppUser)
                    .Include(t => t.Category).ToList();
            }
        }
    }
}
