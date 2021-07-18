using MvcBootcamp.DAL.Abstract;
using MvcBootcamp.Entities.Concrete;
using MvcBootcamp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Concrete.EntityFramework
{
    public class EfHeadlineDal : EfEntityRepositoryBase<Headline, MvcBootcampContext>, IHeadlineDal
    {
        public List<HeadlineDetailDto> GetHeadlineDetails()
        {
            using (MvcBootcampContext context = new MvcBootcampContext())
            {
                var result = from h in context.Headlines
                             join a in context.Authors
                             on h.AuthorId equals a.Id
                             join c in context.Categories
                             on h.CategoryId equals c.Id
                             select new HeadlineDetailDto
                             {
                                 HeadlineId = h.Id,
                                 HeadlineCategory = c.Name,
                                 HeadlineAuthor = a.Nickname,
                                 HeadlineText = h.Text,
                                 HeadlineCreationDate = h.CreationDate,
                                 HeadlineisActive=h.isActive
                             };

                return result.ToList();
            }
        }

        public void SetStatus(int id)
        {
            using (MvcBootcampContext context = new MvcBootcampContext())
            {
                var result = context.Headlines.Find(id);

                if (result.isActive)
                    result.isActive = false;
                else
                    result.isActive = true;

                context.SaveChanges();
            }
        }
    }
}
