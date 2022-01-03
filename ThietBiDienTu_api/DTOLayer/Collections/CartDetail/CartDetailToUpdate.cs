using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.CartDetail
{
    public class CartDetailToUpdate: BaseEntity
    {
        public int Quantity { get; set; }
        public int? PDId { get; set; }
        public int? ProductId { get; set; }
        public int? CartId { get; set; }
    }
}
