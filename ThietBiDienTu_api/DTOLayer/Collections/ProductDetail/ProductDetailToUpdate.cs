using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.ProductDetail
{
    public class ProductDetailToUpdate : BaseEntity
    {
        public int? ProductId { get; set; }
        public int? ProductColorId { get; set; }
        public int? Product_TypeId { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public string ImageFile { get; set; }
    }
}
