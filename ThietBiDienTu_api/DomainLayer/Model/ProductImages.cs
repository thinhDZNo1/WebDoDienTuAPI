using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ProductImages : BaseEntity
    {
        public int? ProductId { get; set; }
        public string Images { get; set; }
        public virtual Product Product { get; set; }
    }
}
