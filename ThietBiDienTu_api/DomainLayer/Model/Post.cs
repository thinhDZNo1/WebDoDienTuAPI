
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
    }
}
