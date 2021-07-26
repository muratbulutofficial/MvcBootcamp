using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.DTOs
{
    public class AuthorDetailDto : IDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEMail { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorAbout{ get; set; }
        public string AuthorIpAddress { get; set; }
        public string AuthorLevel{ get; set; }
        public DateTime AuthorRegister{ get; set; }
        public DateTime AuthorLastLogin{ get; set; }
        public bool AuthorIsActive { get; set; }
    }
}
