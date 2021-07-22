using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.Entities.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            Headlines = new List<Headline>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Sorting { get; set; }
        public bool IsActive { get; set; }
        public string SeoUrl { get; set; }
        public List<Headline> Headlines { get; set; }
    }
}
