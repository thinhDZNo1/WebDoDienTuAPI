using DTOlayer.Collections.Product;
using DTOlayer.Collections.ProductDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.CartDetail
{
    public class CartDetailToGet: BaseEntity
    {
        public int Quantity { get; set; }
        public int? PDId { get; set; }
        public int? ProductId { get; set; }
        public int? CartId { get; set; }
        [NotMapped]
        public virtual ProductToGet Product { get; set; }
        [NotMapped]
        public virtual ProductDetailToGet ProductDetail { get; set; }
    }
}
