using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.Concrete
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public bool isRead { get; set; }
        public DateTime DateTime { get; set; }
    }
}
