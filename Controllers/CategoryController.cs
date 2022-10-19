using CodeFirstApproach.ApplicationDbContext;
using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    


    public class CategoryController : Controller
    {
        //AppDbContext db = new AppDbContext();

        private AppDbContext db;
        public CategoryController()
        {
            db = new AppDbContext();
        }

        // GET: Category
        public async Task<ActionResult> Index()
        {

            var category = await db.Categories.ToListAsync();

            return View(category);
        }

        //get create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Category c)
        {
            db.Categories.Add(c);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            var row =await db.Categories.Where(model => model.CategoryId == id).FirstOrDefaultAsync();
            return View(row);
        }
        //post
        [HttpPost]
        public async Task<ActionResult> Edit(Category c)
        {
            db.Entry(c).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryRow =await db.Categories.Where(model => model.CategoryId == id).FirstOrDefaultAsync();
            db.Entry(categoryRow).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Active(int id)
        {
            var act = db.Categories.Single(c => c.CategoryId == id);
            act.IsActive=true;
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Products");
            
            
        }
       
        public async Task<ActionResult> Deactive(int id)
        {
            var deact = db.Categories.Single(c => c.CategoryId == id);
            deact.IsActive = false;
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var DetailsById =await db.Products.Include(c => c.Category)
                .Where(model => model.CategoryId == id && model.Category.IsActive == true)
                .Select(x => new ProductDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    CategoryName = x.Category.Name,
                    CategoryId = x.CategoryId
                }).ToListAsync();

            return View(DetailsById);
        }








    }
    
}