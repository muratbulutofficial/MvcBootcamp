using MvcBootcamp.DAL.Abstract;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, Context>, ICategoryDal
    {
        public void SetStatus(int id)
        {
            using (Context context = new Context())
            {
                var entity = context.Categories.SingleOrDefault(x=>x.Id==id);

                if (entity.Status == true)
                    entity.Status = false;
                else
                    entity.Status = true;


                context.SaveChanges();
            }
            
        }
    }
}
