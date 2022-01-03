﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.ConfirmOrder
{
    public class ConfirmOrderToAdd
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? CartDetailId { get; set; }
        public int Total { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int Payments { get; set; }
    }
}
