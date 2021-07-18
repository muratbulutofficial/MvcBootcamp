using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.DTOs
{
   public class ContentDetailDto:IDto
    {
        public int ContentId { get; set; }
        public string AuthorName { get; set; }
        public string HeadlineName { get; set; }
        public string CategoryName { get; set; }
        public string ContentText { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
