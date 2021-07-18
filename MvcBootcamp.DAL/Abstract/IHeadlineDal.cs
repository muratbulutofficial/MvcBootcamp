using Core.DataAccess;
using MvcBootcamp.Entities.Concrete;
using MvcBootcamp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Abstract
{
   public interface IHeadlineDal:IRepository<Headline>
    {
        List<HeadlineDetailDto> GetHeadlineDetails();
        void SetStatus(int id);
    }
}
