using Core.Aspects.PostSharp.Validation;
using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.ValidationRules.FluentValidation;
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
    public class AuthorManager : IAuthorService
    {
        private EfAuthorDal _authorDal;
        public AuthorManager(EfAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        [ValidationAspect(typeof(AuthorValidator))]
        public void Add(Author author)
        {
            _authorDal.Add(author);
        }

        public List<AuthorDetailDto> GetAuthorDetail()
        {
            return _authorDal.GetAuthorDetails().OrderByDescending(x => x.AuthorId).ToList();
        }

        public List<Author> GetList()
        {
            return _authorDal.Getlist().OrderByDescending(x=>x.Id).ToList();
        }
        
        public bool Login(Author author)
        {
            return _authorDal.Login(author);
        }

        public void SetStatus(int id)
        {
            _authorDal.SetStatus(id);
        }
        [ValidationAspect(typeof(AuthorValidator))]
        public void Update(Author author)
        {
            _authorDal.Update(author);
        }
    }
}
