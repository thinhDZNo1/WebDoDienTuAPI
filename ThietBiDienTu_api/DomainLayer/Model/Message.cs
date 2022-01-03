using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Message : BaseEntity
    {
        public int? UserId { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public int Sender { get; set; }
        public virtual User User { get; set; }
    }
}
