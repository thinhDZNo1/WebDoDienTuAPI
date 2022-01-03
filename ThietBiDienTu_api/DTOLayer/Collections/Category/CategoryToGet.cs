using DTOlayer.Collections.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.Category
{
    public class CategoryToGet : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public string ImageFile { get; set; }
        [NotMapped]
        public List<ProductToGet> Product { get; set; }
    }
}
