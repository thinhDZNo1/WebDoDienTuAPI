using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ConfirmOrder : BaseEntity
    {
        public int? CartDetailId { get; set; }
        public int Total { get; set; }
        public int Quantity { get; set; }
        public int? UserId { get; set; }
        public int Payments { get; set; }
        public virtual CartDetail CartDetail { get; set; }
        public virtual User User { get; set; }
    }
}
