using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Cart:BaseEntity
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public List<CartDetail> CartDetail { get; set; }
    }
}
