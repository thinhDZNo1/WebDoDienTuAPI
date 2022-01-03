using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.Message
{
    public class MessageToUpdate : BaseEntity
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public int Sender { get; set; }
    }
}
