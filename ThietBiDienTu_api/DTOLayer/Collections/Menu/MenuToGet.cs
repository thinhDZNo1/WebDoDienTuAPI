﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.Collections.Menu
{
    public class MenuToGet : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
    }
}
