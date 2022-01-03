using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.Product
{
    public class ProductToUpdate : BaseEntity
    {
        public string Name { get; set; }
        public string Images { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryDetailId { get; set; }
        [NotMapped]
        public string ImageFile { get; set; }
    }
}
