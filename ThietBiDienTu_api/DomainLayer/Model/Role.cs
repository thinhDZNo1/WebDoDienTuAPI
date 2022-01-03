using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Role: BaseEntity
    {
        public String Name { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
