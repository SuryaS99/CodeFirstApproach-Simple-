using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}