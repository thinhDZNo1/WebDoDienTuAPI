using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public List<CategoryDetail> CategoryDetails { get; set; }
    }
}
