using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ProductReview : BaseEntity
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int NumberOfStars { get; set; }
        public string Content { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
