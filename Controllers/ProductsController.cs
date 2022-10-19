using CodeFirstApproach.ApplicationDbContext;
using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class ProductsController : Controller
    {
        //AppDbContext db = new AppDbContext();
        private AppDbContext db;

        public ProductsController()
        {
            db = new AppDbContext();
        }
        
        public ActionResult Index()
        {
            var prct = db.Products.Include(c => c.Category).Where(x => x.Category.IsActive == true).ToList();
            
            return View(prct);
            
        }
        


        //get create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction( "Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id","Name",product.CategoryId);
            return View(product);
        }
        //get Edit
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            var row = db.Products.Where(model => model.ProductId == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            var Delrow = db.Products.Where(model => model.ProductId == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Entry(Delrow).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", id);
            return View(Delrow);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            var Detailrow = db.Products.Where(model => model.ProductId == id).FirstOrDefault();
            return View(Detailrow);
        }
        
    }
}