using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.DAL.Concrete.EntityFramework;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.Concrete
{
    public class SkillManager : ISkillService
    {
        public SkillManager(EfSkillDal efSkillDal)
        {
            _skillDal = efSkillDal;
        }
        private EfSkillDal _skillDal;

        public List<Skill> GetList()
        {
            return _skillDal.Getlist();
        }
    }
}
