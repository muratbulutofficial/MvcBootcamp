using Core.Aspects.PostSharp.Validation;
using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.ValidationRules.FluentValidation;
using MvcBootcamp.DAL.Concrete.EntityFramework;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private EfCategoryDal _categoryDal;
        public CategoryManager(EfCategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public Category Find(int id)
        {
            return _categoryDal.Find(x=>x.Id==id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.Getlist().OrderByDescending(x => x.Id).ToList();
        }

        public void Remove(Category category)
        {
            _categoryDal.Remove(category);
        }

        public void SetStatus(int id)
        {
            _categoryDal.SetStatus(id);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}

