using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void Add(Category category);
        Category Find(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}
