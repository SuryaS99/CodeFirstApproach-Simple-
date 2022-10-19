using CodeFirstApproach.ApplicationDbContext;
using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeFirstApproach.Controllers.Api
{        
    public class CategoryController : ApiController
    {

        private AppDbContext _context;
            public CategoryController()
        {
            _context = new AppDbContext();  
        }

        // Get/api/Category (Multiple category)
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        // Get /api/Category/1

        public Category GetCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return category;

        }

        //post /api/Category

        public Category CreateCategories(Category category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }


        //PUT/api/Category/1
        [HttpPut]
        public void UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var categoryInDb = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            categoryInDb.Name = category.Name;
            // categoryInDb.Name = category.Name;

            _context.SaveChanges();
        }

        //Delete/api/Category/1
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
        }
    }
}
