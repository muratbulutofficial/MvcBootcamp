using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.DAL.Concrete.EntityFramework;
using MvcBootcamp.Entities.Concrete;
using MvcBootcamp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Concrete
{
    public class ContentManager : IContentService
    {
        private EfContentDal _contentDal;
        public ContentManager(EfContentDal efContentDal)
        {
            _contentDal = efContentDal;
        }

        public List<ContentDetailDto> GetContentDetails()
        {
            return _contentDal.GetContentDetails().OrderByDescending(x=>x.ContentId).ToList();
        }

        public List<Content> GetList()
        {
            return _contentDal.Getlist();
        }
    }
}
