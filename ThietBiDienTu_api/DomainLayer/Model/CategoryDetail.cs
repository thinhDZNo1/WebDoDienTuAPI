using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class CategoryDetail :BaseEntity
    { 
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int? CategoryId{ get; set; }
        public virtual Category Category { get; set; }
        public List<Product> Product { get; set; }
    }
}
