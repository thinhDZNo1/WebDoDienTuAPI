using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Images { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryDetailId { get; set; }
        public virtual Company Company { get; set; }
        public virtual CategoryDetail CategoryDetail { get; set; }
        public List<ProductReview> ProductReviews { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
        public List<ProductImages> ProductImages { get; set; }
        public List<CartDetail> CartDetail  { get; set; }
    }
}
