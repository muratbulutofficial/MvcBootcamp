using MvcBootcamp.Entities.Concrete;
using MvcBootcamp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetList();
        List<AuthorDetailDto> GetAuthorDetail();
        void Add(Author author);
        void SetStatus(int id);
        bool PanelLogin(Author author);

    }
}
