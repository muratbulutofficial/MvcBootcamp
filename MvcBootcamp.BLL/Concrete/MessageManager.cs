using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.DAL.Concrete.EntityFramework;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Concrete
{
    public class MessageManager : IMessageService
    {
        public MessageManager(EfMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        private EfMessageDal _messageDal;
        public List<Message> GetList()
        {
            return _messageDal.Getlist().OrderByDescending(x=>x.Id).ToList();
        }

        public Message Find(int id)
        {
            return _messageDal.Find(x=>x.Id.Equals(id));
        }

        public void SetRead(int id)
        {
            _messageDal.SetRead(id);
        }
    }
}
