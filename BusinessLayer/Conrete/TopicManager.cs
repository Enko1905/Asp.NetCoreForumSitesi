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
    public class TopicManager : ITopicService
    {
        ITopicDal _topicDal;
        public TopicManager(ITopicDal topicDal)
        {
            _topicDal = topicDal;
        }
        public List<Topic> GetAll()
        {
            return _topicDal.GetAll();
        }

        [Obsolete(message:"Bunun Yerin GetTopicListWithCategoryAndUser Kullan")]
        public Task<List<Topic>> GetPostListWithUserAsync()
        {
            return _topicDal.GetPostListWithUserAsync();
        }

        public List<Topic> GetTopicListWithCategory()
        {
            return _topicDal.GetTopicListWithCategory();
        }

        public List<Topic> GetTopicListWithCategoryAndUser()
        {
            return _topicDal.GetTopicListWithCategoryAndUser();
        }

        public void TDelete(Topic t)
        {
            _topicDal.Delete(t);
        }

        public Topic TGetById(int id)
        {
            return _topicDal.GetById(id);
        }

        public void TInsert(Topic t)
        {
            _topicDal.Insert(t);
        }

        public void TUpdate(Topic t)
        {
            _topicDal.Update(t);
        }
    }
}
