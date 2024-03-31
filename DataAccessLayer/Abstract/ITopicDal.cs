using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITopicDal:IGenericDal<Topic>
    {
        List<Topic> GetTopicListWithCategory();
        List<Topic> GetTopicListWithCategoryAndUser();
        Task<List<Topic>> GetPostListWithUserAsync();

    }

}
