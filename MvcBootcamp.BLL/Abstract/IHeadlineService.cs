using MvcBootcamp.Entities.Concrete;
using MvcBootcamp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Abstract
{
    public interface IHeadlineService
    {
        List<Headline> GetList();
        Headline Find(int id);
        void Add(Headline headline);
        void Update(Headline headline);
        void Remove(Headline headline);
        List<HeadlineDetailDto> GetHeadlineDetails();
        void SetStatus(int id);

    }
}
