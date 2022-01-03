using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Menu : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
    }
}
