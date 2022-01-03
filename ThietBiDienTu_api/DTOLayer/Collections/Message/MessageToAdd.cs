using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.Message
{
    public class MessageToAdd
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public int Sender { get; set; }
    }
}
