using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }


        [Display(Name ="Product Name")]
        public string ProductName { get; set; }


        
        [ForeignKey("CategoryId")]
        
        public virtual Category Category { get; set; }
        public virtual int CategoryId { get; set; }
    }
}