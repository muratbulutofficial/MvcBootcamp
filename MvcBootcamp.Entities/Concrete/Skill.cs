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
        public byte Id { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
        public int Value { get; set; }
    }
}
