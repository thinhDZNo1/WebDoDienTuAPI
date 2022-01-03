using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Slide : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
