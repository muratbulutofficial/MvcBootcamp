using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.Concrete
{
   public class UserLevel:IEntity
    {
        public UserLevel()
        {
            Authors = new List<Author>();
        }
        public byte Id { get; set; }
        public string Level { get; set; }
        public List<Author> Authors { get; set; }
    }
}
