using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Abstract
{
   public interface ISkillService
    {
        List<Skill> GetList();
        void Add(Skill skill);
        void Update(Skill skill);
        void Remove(Skill skill);
    }
}
