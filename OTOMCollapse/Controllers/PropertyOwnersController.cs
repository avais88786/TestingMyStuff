using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTOMCollapse.Models;
using OTOMCollapse.Infrastructure;
using OTOMCollapse.Models.ViewModels;
using StructureMap;
using OTOMCollapse.DependenctResolver;
using AutoMapper;
using OTOMCollapse.Models.ViewModels.PropertyOwners;
using OTOMCollapse.Models.RepeatGroups;

namespace OTOMCollapse.Controllers
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

            Mapper.CreateMap<CompanyStatus, SelectListItem>()
                  .ForMember(listItem => listItem.Value, model => model.MapFrom(src => src.CompanyStatusId))
                  .ForMember(listItem => listItem.Text, model => model.MapFrom(src => src.CompanyStatusText));

            Mapper.CreateMap<Location, SelectListItem>()
                  .ForMember(listItem => listItem.Value, model => model.MapFrom(src => src.Id))
                  .ForMember(listItem => listItem.Text, model => model.MapFrom(src => src.Text));


            ICompanyStatusRepository companyStatusRepo = StructureMapContainer.Container.GetInstance<ICompanyStatusRepository>(); // ObjectFactory.GetInstance<ICompanyStatusRepository>();
            IRepository<Location> locationRepo = StructureMapContainer.Container.GetInstance<IRepository<Location>>();
            //SelectList list = new SelectList(companyStatusRepo.GetAll());
            PropertyOwnersViewModel vm = new PropertyOwnersViewModel();
            vm.CompanyStatuses = Mapper.Map<IList<CompanyStatus>,IList<SelectListItem>>(companyStatusRepo.GetAll());
            vm.PropertyLocations = Mapper.Map<IList<Location>,IList<SelectListItem>>(locationRepo.GetAll());
            return View(vm);
        }

        //
        // POST: /PropertyOwners/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProposerName,CompanyStatus,Properties")] PropertyOwnersViewModel propertyowners)
        {
            if (ModelState.IsValid)
            {
                db.PropertyOwners.Add(propertyowners);
                db.SaveChanges();
                return RedirectToAction("Create");
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