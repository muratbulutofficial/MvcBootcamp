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
    public interface IContentDal : IRepository<Content>
    {
        List<ContentDetailDto> GetContentDetails();
    }
}
