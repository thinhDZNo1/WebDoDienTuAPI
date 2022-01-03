using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Product_Type : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
