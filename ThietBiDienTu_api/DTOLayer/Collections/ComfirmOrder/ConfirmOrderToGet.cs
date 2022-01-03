using DTOlayer.Collections.CartDetail;
using DTOlayer.Collections.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.ConfirmOrder
{
    public class ConfirmOrderToGet : BaseEntity
    {
        public int? CartDetailId { get; set; }
        public int Total { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int Payments { get; set; }
        [NotMapped]
        public CartDetailToGet CartDetail { get; set; }
    }
}
