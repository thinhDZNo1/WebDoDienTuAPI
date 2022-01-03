using DTOlayer.Collections.CategoryDetail;
using DTOlayer.Collections.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.ProductImages
{
    public class ProductImagesToGet : BaseEntity
    {
        public int? ProductId { get; set; }
        public string Images { get; set; }
        [NotMapped]
        public string ImageFile { get; set; }
    }
}
