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
    public class EfContentDal : EfEntityRepositoryBase<Content, Context>, IContentDal
    {
        public List<ContentDetailDto> GetContentDetails()
        {
            using (Context context =new Context()) 
            {
                var result = from c in context.Contents
                             join a in context.Authors
                             on c.AuthorId equals a.Id
                             join h in context.Headlines
                             on c.HeadlineId equals h.Id
                             select new ContentDetailDto
                             {
                                 ContentId = c.Id,
                                 AuthorName = a.Nickname,
                                 HeadlineName = h.Text,
                                 ContentText = c.Text,
                                 CreationDate = c.CreationDate
                             };

                return result.ToList();
            }

        }
    }
}
