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
        Task<List<Topic>> GetPostListWithUserAsync();

    }

}
