using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("CatD")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
    }
    
}