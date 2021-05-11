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
    public class HeadlineManager : IHeadlineService
    {
        private EfHeadlineDal _headlineDal;
        public HeadlineManager(EfHeadlineDal headlineDal)
        {
            _headlineDal = headlineDal;
        }
        public List<Headline> GetList()
        {
            return _headlineDal.Getlist();
        }
    }
}
