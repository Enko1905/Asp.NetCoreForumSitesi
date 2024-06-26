﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITopicService:IGenericService<Topic>
    {
        [Obsolete]
        List<Topic> GetTopicListWithCategory();
        Task<List<Topic>> GetPostListWithUserAsync();
        List<Topic> GetTopicListWithCategoryAndUser();


    }
}
