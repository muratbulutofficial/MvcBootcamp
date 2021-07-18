using MvcBootcamp.DAL.Abstract;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, MvcBootcampContext>, IMessageDal
    {
        public void SetRead(int id)
        {
            using (MvcBootcampContext context =new MvcBootcampContext())
            {
                var msg = context.Messages.Find(id);
                if (msg.isRead == false)
                    msg.isRead = true;
                context.SaveChanges();
            }
        }
    }
}
