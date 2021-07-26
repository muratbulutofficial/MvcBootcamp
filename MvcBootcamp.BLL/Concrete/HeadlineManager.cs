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
    public class HeadlineManager : IHeadlineService
    {
        private EfHeadlineDal _headlineDal;
        public HeadlineManager(EfHeadlineDal headlineDal)
        {
            _headlineDal = headlineDal;
        }
        [ValidationAspect(typeof(HeadlineValidator))]
        public void Add(Headline headline)
        {
            _headlineDal.Add(headline);
        }

        public Headline Find(int id)
        {
            return _headlineDal.Find(x=>x.Id.Equals(id));
        }

        public List<HeadlineDetailDto> GetHeadlineDetails()
        {
            return _headlineDal.GetHeadlineDetails().OrderByDescending(x=>x.HeadlineId).ToList();
        }

        public List<Headline> GetList()
        {
            return _headlineDal.Getlist().OrderByDescending(x => x.Id).ToList();
        }

        public void Remove(Headline headline)
        {
            _headlineDal.Remove(headline);
        }

        public void SetStatus(int id)
        {
            _headlineDal.SetStatus(id);
        }
        [ValidationAspect(typeof(HeadlineValidator))]
        public void Update(Headline headline)
        {
            _headlineDal.Update(headline);
        }
    }
}
