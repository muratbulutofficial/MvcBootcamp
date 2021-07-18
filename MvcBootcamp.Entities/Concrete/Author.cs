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
            RegisterDate = DateTime.Now;
            LastLoginDate = DateTime.Now;
        }

        public int Id { get; set; }
        public byte? UserLevelId { get; set; }
        public string Nickname { get; set; }
        public string Image { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string About { get; set; }
        public string IpAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public virtual UserLevel UserLevel { get; set; }
        public List<Content> Contents { get; set; }
        public List<Headline> Headlines { get; set; }
    }
}
