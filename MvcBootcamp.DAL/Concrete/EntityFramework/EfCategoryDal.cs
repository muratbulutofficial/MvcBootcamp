using MvcBootcamp.DAL.Abstract;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, MvcBootcampContext>, ICategoryDal
    {
        public void SetStatus(int id)
        {
            using (MvcBootcampContext context = new MvcBootcampContext())
            {
                var entity = context.Categories.SingleOrDefault(x=>x.Id==id);

                if (entity.IsActive == true)
                    entity.IsActive = false;
                else
                    entity.IsActive = true;


                context.SaveChanges();
            }
            
        }
    }
}
