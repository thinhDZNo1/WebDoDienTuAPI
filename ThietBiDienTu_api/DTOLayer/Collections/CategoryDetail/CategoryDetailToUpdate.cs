using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.CategoryDetail
{
    public class CategoryDetailToUpdate : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int? CategoryId{ get; set; }
        [NotMapped]
        public string ImageFile { get; set; }
    }
}
