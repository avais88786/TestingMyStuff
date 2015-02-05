using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTOMTests.Models;
using OTOMTests.Infrastructure;
using OTOMTests.Models.ViewModels;

namespace OTOMTests.Controllers
{
    public class PropertyOwnersController : Controller
    {
        private OTOMTestsDataContext db = new OTOMTestsDataContext();

        //
        // GET: /PropertyOwners/

        public ActionResult Index()
        {
            Type type = typeof(PropertyOwnersViewModel);
            var attr = type.GetProperty("Property").CustomAttributes;
            
            
            return View(db.PropertyOwners.ToList());


            
        }

        //
        // GET: /PropertyOwners/Details/5

        public ActionResult Details(int id = 0)
        {
            PropertyOwnersViewModel propertyowners = db.PropertyOwners.Find(id);
            if (propertyowners == null)
            {
                return HttpNotFound();
            }
            return View(propertyowners);
        }

        //
        // GET: /PropertyOwners/Create

        public ActionResult Create()
        {
            Type type = typeof(PropertyOwnersViewModel);
            var attr = ((MaximumPropertyRepeatGroupsAttribute)type.GetProperty("Property").GetCustomAttributes(typeof(MaximumPropertyRepeatGroupsAttribute), false).SingleOrDefault()).MaxPRGValue;
            
            return View();
        }

        //
        // POST: /PropertyOwners/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyOwnersViewModel propertyowners)
        {
            if (ModelState.IsValid)
            {
                db.PropertyOwners.Add(propertyowners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyowners);
        }

        //
        // GET: /PropertyOwners/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PropertyOwnersViewModel propertyowners = db.PropertyOwners.Find(id);
            if (propertyowners == null)
            {
                return HttpNotFound();
            }
            return View(propertyowners);
        }

        //
        // POST: /PropertyOwners/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PropertyOwnersViewModel propertyowners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyowners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyowners);
        }

        //
        // GET: /PropertyOwners/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PropertyOwnersViewModel propertyowners = db.PropertyOwners.Find(id);
            if (propertyowners == null)
            {
                return HttpNotFound();
            }
            return View(propertyowners);
        }

        //
        // POST: /PropertyOwners/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyOwnersViewModel propertyowners = db.PropertyOwners.Find(id);
            db.PropertyOwners.Remove(propertyowners);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}