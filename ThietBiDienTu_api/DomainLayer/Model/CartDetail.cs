using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class CartDetail : BaseEntity
    {
        public int? CartId { get; set; }
        public int Quantity { get; set; }
        public int? PDId { get; set; }
        public int? ProductId { get; set; }
        public  virtual Cart Cart { get; set; }
        public  virtual ProductDetail ProductDetail { get; set; }
        public  virtual Product Product { get; set; }
    }
}
