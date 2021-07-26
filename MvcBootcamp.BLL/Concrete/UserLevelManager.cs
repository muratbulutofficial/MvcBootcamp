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
    public class UserLevelManager : IUserLevelService
    {
        public UserLevelManager(EfUserLevelDal userLevelDal)
        {
            _userLevelDal = userLevelDal;
        }
        private EfUserLevelDal _userLevelDal;
        public List<UserLevel> GetList()
        {
           return _userLevelDal.Getlist();
        }
    }
}
