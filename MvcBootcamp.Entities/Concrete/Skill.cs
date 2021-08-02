using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.Concrete
{
    public class Skill:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PerValue { get; set; }
        public string Value { get; set; }
    }
}
