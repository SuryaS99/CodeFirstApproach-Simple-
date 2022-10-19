using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name ="Active")]
        public bool IsActive { get; set; }
    }
}