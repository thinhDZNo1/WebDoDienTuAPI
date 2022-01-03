using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.CartDetail
{
    public class CartDetailToAdd
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public int? CartId { get; set; }
        public int? PDId { get; set; }
        public int? ProductId { get; set; }
        [NotMapped]
        public int? UserId { get; set; }
    }
}
