﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.API.Testing.RestSharp.Models
{
    public class Components
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
