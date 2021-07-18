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
    public class HeadlineManager : IHeadlineService
    {
        private EfHeadlineDal _headlineDal;
        public HeadlineManager(EfHeadlineDal headlineDal)
        {
            _headlineDal = headlineDal;
        }

        public List<HeadlineDetailDto> GetHeadlineDetails()
        {
            return _headlineDal.GetHeadlineDetails().OrderByDescending(x=>x.HeadlineId).ToList();
        }

        public List<Headline> GetList()
        {
            return _headlineDal.Getlist();
        }

        public void SetStatus(int id)
        {
            _headlineDal.SetStatus(id);
        }
    }
}
