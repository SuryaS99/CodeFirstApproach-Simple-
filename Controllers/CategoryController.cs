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
    public class CategoryController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Category
        public ActionResult Index()
        {

            var category = db.Categories.ToList();

            return View(category);
        }

        //get create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
            return View(row);
        }
        //post
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //get delete
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    var categoryRow = db.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
        //    return View(categoryRow);
        //}

        //post delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var categoryRow = db.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
            db.Entry(categoryRow).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        


    }
}