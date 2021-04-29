using MvcBootcamp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.Concrete
{
    public class Content : IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int HeadlineId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Headline Headline { get; set; }
        public virtual Author Author { get; set; }
    }
}
