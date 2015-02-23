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
using OTOMCollapse.Models.Helpers;

namespace OTOMCollapse.Controllers
{
    public class PropertyOwnersController : Controller
    {
        private OTOMTestsDataContext db = new OTOMTestsDataContext();
        private Dictionary<string, RepeatGroupContainer> propertyMapping;

        public PropertyOwnersController()
        {
            Mapper.CreateMap<CodeListBase, SelectListItem>()
                  .ForMember(listItem => listItem.Value, model => model.MapFrom(src => src.ABICode))
                  .ForMember(listItem => listItem.Text, model => model.MapFrom(src => src.Text));

            propertyMapping = new Dictionary<string, RepeatGroupContainer>();
            //propertyMapping.Add("StandardQuestionsGroupViewModel", new StandardQuestionsGroupViewModel());
            //propertyMapping.Add("SubsidiaryRepeatGroup", new SubsidiaryRepeatGroup());
            

            //Mapper.CreateMap<SprinklerCodeList, SelectListItem>()
            //      .ForMember(listItem => listItem.Value, model => model.MapFrom(src => src.ABICode))
            //      .ForMember(listItem => listItem.Text, model => model.MapFrom(src => src.Text));
                  
        }

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

            ICompanyStatusRepository companyStatusRepo = StructureMapContainer.Container.GetInstance<ICompanyStatusRepository>(); // ObjectFactory.GetInstance<ICompanyStatusRepository>();
            IRepository<CodeListBase> sprinklersCodeListRepo = StructureMapContainer.Container.GetInstance<IRepository<CodeListBase>>();
            //SelectList list = new SelectList(companyStatusRepo.GetAll());
            PropertyOwnersViewModel vm = new PropertyOwnersViewModel();
            //IEnumerable<string> codeListNames
            var x = vm.GetCodeListNames();
            
            //vm.CompanyStatuses = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(companyStatusRepo.GetAll());
            //vm.Trades = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(sprinklersCodeListRepo.GetAll());
            return View("Object",vm);
        }

        //
        // POST: /PropertyOwners/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyOwnersViewModel propertyowners)
        {
            //if (ModelState.IsValid)
            //{
            //    db.PropertyOwners.Add(propertyowners);
            //    db.SaveChanges();
            //    return RedirectToAction("Create");
            //}

            ICompanyStatusRepository companyStatusRepo = StructureMapContainer.Container.GetInstance<ICompanyStatusRepository>(); // ObjectFactory.GetInstance<ICompanyStatusRepository>();
            IRepository<CodeListBase> sprinklersCodeListRepo = StructureMapContainer.Container.GetInstance<IRepository<CodeListBase>>();

            //propertyowners.CompanyStatuses = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(companyStatusRepo.GetAll());
            //propertyowners.Trades = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(sprinklersCodeListRepo.GetAll());

            return View("Object",propertyowners);
        }

        public ActionResult avais(string property, int nextIndex, string htmlTemplateFieldPrefix)
        {
            PropertyOwnersViewModel viewModel = new PropertyOwnersViewModel();
            var type = viewModel.GetRepeatGroupContainerType(property);
            //var x = propertyMapping[container];
            //x.propertyName = property;
            ViewData["property"] = property;
            ViewData["Index"] = nextIndex;
            ViewData["idToAppend"] = property;
            ViewData["htmlFieldPrefix"] = htmlTemplateFieldPrefix;

            //htmlTemplateFieldPrefix = htmlTemplateFieldPrefix.Substring(0,(htmlTemplateFieldPrefix.Length-3));
            //ViewData["htmlFieldPrefix"] = String.Format("{0}[{1}]", htmlTemplateFieldPrefix, nextIndex);
            return PartialView("Partial/_PartialGenericRepeatGroupListStyle", type);
        }


        //public ActionResult DisplayCodeListSelectedValue(string id,string selectedText)
        //{
        //    ICompanyStatusRepository companyStatusRepo = StructureMapContainer.Container.GetInstance<ICompanyStatusRepository>(); // ObjectFactory.GetInstance<ICompanyStatusRepository>();
        //    var x = Mapper.Map<IList<CompanyStatus>, IList<SelectListItem>>(companyStatusRepo.GetAll());
        //    var z = x.Single(y => y.Value == id);

        //    return Json(String.Concat(z.Text," ABI Code : ",z.Value));
        //}

        //public ActionResult DisplayCodeListSelectedValue(PropertyOwnersViewModel propertyowners)
        //{
        //   string z = String.Concat(propertyowners.Sprinkler, " ABI Code : ", z.Value)

        //    return Json(String.Concat(z.Text, " ABI Code : ", z.Value));
        //}


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