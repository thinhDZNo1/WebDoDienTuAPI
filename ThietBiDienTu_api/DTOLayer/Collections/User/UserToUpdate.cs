using DTOlayer.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Collections.User
{
    public class UserToUpdate: BaseEntity
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
        [NotMapped]
        public string ImageFile { get; set; }
    }
}
