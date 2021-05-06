using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.Concrete
{
    public class Headline : IEntity
    {
        public Headline()
        {
            Contents = new List<Content>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public List<Content> Contents { get; set; }
    }
}
