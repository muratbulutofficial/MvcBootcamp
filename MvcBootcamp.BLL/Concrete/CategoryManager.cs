using MvcBootcamp.DAL.Concrete.EntityFramework;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Concrete
{
    public class CategoryManager
    {
        EfEntityRepositoryBase<Category, Context> bg = new EfEntityRepositoryBase<Category, Context>();
        public List<Category> GetList()
        {
            return bg.Getlist();
        }

        public void Add(Category category)
        {
            if (category.Name == "" || category.Name.Length <= 3 || category.Name.Length >= 15 || category.Description == "")
            {
                //Error Message Field
            }
            else
            {
                bg.Add(category);
            }
        }
    }
}
