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
    public class EfAuthorDal:EfEntityRepositoryBase<Author,MvcBootcampContext>,IAuthorDal
    {
        public List<AuthorDetailDto> GetAuthorDetails()
        {
            using (MvcBootcampContext context = new MvcBootcampContext())
            {
                var result = from u in context.UserLevels
                             join a in context.Authors
                             on u.Id equals a.UserLevelId
                             select new AuthorDetailDto
                             {
                                 AuthorId = a.Id,
                                 AuthorName = a.Nickname,
                                 AuthorEMail = a.EMail,
                                 AuthorImage=a.Image,
                                 AuthorAbout=a.About,
                                 AuthorIpAddress = a.IpAddress,
                                 AuthorLevel = u.LevelName,
                                 AuthorRegister=a.RegisterDate,
                                 AuthorLastLogin=a.LastLoginDate,
                                 AuthorIsActive=a.IsActive
                             };

                return result.ToList();
            }

        }

        public bool Login(Author author)
        {
            using (MvcBootcampContext context = new MvcBootcampContext())
            {

                var result = context.Authors.FirstOrDefault(x => x.EMail.Equals(author.EMail) && x.Password.Equals(author.Password) && x.IsActive.Equals(true));

                if (result != null)
                {
                    if (result.EMail.Equals(author.EMail) && result.Password.Equals(author.Password))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public void SetStatus(int id)
        {
            using (MvcBootcampContext context = new MvcBootcampContext())
            {
                var result = context.Authors.Find(id);

                if (result.IsActive)
                    result.IsActive = false;
                else
                    result.IsActive = true;

                context.SaveChanges();
            }
        }
    }
}
