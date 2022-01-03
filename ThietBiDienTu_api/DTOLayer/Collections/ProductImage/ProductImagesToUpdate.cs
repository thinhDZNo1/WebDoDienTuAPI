using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.ProductImages
{
    public class ProductImagesToUpdate : BaseEntity
    {
        public int? ProductId { get; set; }
        public string Images { get; set; }
    }
}
