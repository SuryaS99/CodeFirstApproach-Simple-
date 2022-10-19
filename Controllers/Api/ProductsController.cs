using CodeFirstApproach.ApplicationDbContext;
using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;


namespace CodeFirstApproach.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private AppDbContext _context;

        public ProductsController()
        {
            //initialize the variable
            _context = new AppDbContext();
        }
      
        public IEnumerable<Product> GetProducts()
        {

            var pract=_context.Products.Include(c => c.Category).Where(x => x.Category.IsActive == true).ToList();
            return pract;
        }
        //Get/api/Product/1

        public Product GetProduct(int id)
        {

            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        [HttpPost]
        public Product CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        [HttpPut]
        public Product UpdateProduct(int id,Product product)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var ProductInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);
            if (ProductInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ProductInDb.ProductName = product.ProductName;
            _context.SaveChanges();
            return product;
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        { 
        var ProductInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);
            if (ProductInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Products.Remove(ProductInDb);
            _context.SaveChanges();
        }

        }
}
