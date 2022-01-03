using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ProductDetail : BaseEntity
    {
        public int? ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? Product_TypeId { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
        public virtual Product_Type Product_Type { get; set; }
        public List<CartDetail> CartDetail { get; set; }
    }
}
