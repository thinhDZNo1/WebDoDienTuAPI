using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public List<Product> Product { get; set; }
    }
}
