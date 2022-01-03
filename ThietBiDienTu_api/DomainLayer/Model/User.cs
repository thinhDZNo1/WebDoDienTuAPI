﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Avatar { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Cart> Cart { get; set; }
        public List<Message> Message { get; set; }
        public List<UserRole> UserRole { get; set; }
        public List<ProductReview> ProductReview { get; set; }
        public List<ConfirmOrder> ConfirmOrder { get; set; }
    }
}
