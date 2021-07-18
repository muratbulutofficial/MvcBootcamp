using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.DTOs
{
    public class HeadlineDetailDto:IDto
    {
        public int HeadlineId { get; set; }
        public string HeadlineCategory { get; set; }
        public string HeadlineAuthor { get; set; }
        public string HeadlineText{ get; set; }
        public bool HeadlineisActive { get; set; }
        public DateTime HeadlineCreationDate{ get; set; }
    }
}
