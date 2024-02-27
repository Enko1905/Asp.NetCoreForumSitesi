using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public List<Post> GetAll()
        {
           return _postDal.GetAll();
        }

        public List<Post> GetPostListWidthTopicAndUser()
        {
            return _postDal.GetPostListWidthTopicAndUser();
        }

        public void TDelete(Post t)
        {
            _postDal.Delete(t);
        }

        public Post TGetById(int id)
        {
            return _postDal.GetById(id);
        }

        public void TInsert(Post t)
        {
            _postDal.Insert(t);
        }

        public void TUpdate(Post t)
        {
            _postDal.Update(t);
        }
    }
}
