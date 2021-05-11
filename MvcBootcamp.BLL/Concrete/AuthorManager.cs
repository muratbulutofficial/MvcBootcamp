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
    public class AuthorManager : IAuthorService
    {
        private EfAuthorDal _authorDal;
        public AuthorManager(EfAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public List<Author> GetList()
        {
            return _authorDal.Getlist();
        }
    }
}
