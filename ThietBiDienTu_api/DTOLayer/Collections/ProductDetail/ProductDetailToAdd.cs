using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.ProductDetail
{
    public class ProductDetailToAdd
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? ProductId { get; set; }
        public string Image { get; set; }
        public int? ProductColorId { get; set; }
        public int? Product_TypeId { get; set; }
        public int Price { get; set; }
    }
}
