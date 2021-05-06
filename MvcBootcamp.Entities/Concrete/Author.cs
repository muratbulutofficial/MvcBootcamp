using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.Concrete
{
    public class Author : IEntity
    {
        public Author()
        {
            Contents = new List<Content>();
            Headlines = new List<Headline>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Image { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<Content> Contents { get; set; }
        public List<Headline> Headlines { get; set; }
    }
}
