using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.Post
{
    public class PostToGet : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        [NotMapped]
        public string ImageFile { get; set; }
    }
}
