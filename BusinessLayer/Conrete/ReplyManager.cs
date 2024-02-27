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
    public class ReplyManager : IReplyService
    {
        public List<Reply> GetAll()
        {
            throw new NotImplementedException();
        }

        public void TDelete(Reply t)
        {
            throw new NotImplementedException();
        }

        public Reply TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Reply t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Reply t)
        {
            throw new NotImplementedException();
        }
    }
}
