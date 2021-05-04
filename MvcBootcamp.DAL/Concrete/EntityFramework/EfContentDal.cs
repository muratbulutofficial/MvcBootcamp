using MvcBootcamp.DAL.Abstract;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Concrete.EntityFramework
{
    public class EfContentDal: EfEntityRepositoryBase<Content, Context>, IContentDal
    {
    }
}
