using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.ProductReview
{
    public class ProductReviewToAdd
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public int NumberOfStars { get; set; }
        public string Content { get; set; }
    }
}
