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
using OTOMCollapse.ViewModels.PropertyOwners;
using OTOMCollapse.ViewModels;


namespace OTOMCollapse.Controllers
{
    public class PropertyOwnersController : Controller
    {
        private OTOMTestsDataContext db = new OTOMTestsDataContext();
        

        public PropertyOwnersController()
        {
                  
        }

   

        public ActionResult Create()
        {

            //ICompanyStatusRepository companyStatusRepo = StructureMapContainer.Container.GetInstance<ICompanyStatusRepository>(); // ObjectFactory.GetInstance<ICompanyStatusRepository>();
            //IRepository<CodeListBase> sprinklersCodeListRepo = StructureMapContainer.Container.GetInstance<IRepository<CodeListBase>>();
            ////SelectList list = new SelectList(companyStatusRepo.GetAll());
            PropertyOwnersViewModel vm = new PropertyOwnersViewModel();
            //IEnumerable<string> codeListNames
            //var x = vm.GetCodeListNames();
            
            //vm.CompanyStatuses = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(companyStatusRepo.GetAll());
            //vm.Trades = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(sprinklersCodeListRepo.GetAll());
            return View(vm);
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

            //ICompanyStatusRepository companyStatusRepo = StructureMapContainer.Container.GetInstance<ICompanyStatusRepository>(); // ObjectFactory.GetInstance<ICompanyStatusRepository>();
            //IRepository<CodeListBase> sprinklersCodeListRepo = StructureMapContainer.Container.GetInstance<IRepository<CodeListBase>>();

            //propertyowners.CompanyStatuses = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(companyStatusRepo.GetAll());
            //propertyowners.Trades = Mapper.Map<IList<CodeListBase>, IList<SelectListItem>>(sprinklersCodeListRepo.GetAll());

            return View(propertyowners);
        }

        public ActionResult avais(string property, int nextIndex, string htmlTemplateFieldPrefix,string container)
        {
            //PropertyOwnersViewModel viewModel = new PropertyOwnersViewModel();
            var containerType = (IRepeatGroupContainer)Activator.CreateInstance(Type.GetType(container));
            var repeatGroup = containerType.GetPropertyType(property);

            
            ViewData["property"] = property;
            ViewData["Index"] = nextIndex;
            ViewData["idToAppend"] = property;
            ViewData["htmlFieldPrefix"] = htmlTemplateFieldPrefix;

            //htmlTemplateFieldPrefix = htmlTemplateFieldPrefix.Substring(0,(htmlTemplateFieldPrefix.Length-3));
            //ViewData["htmlFieldPrefix"] = String.Format("{0}[{1}]", htmlTemplateFieldPrefix, nextIndex);
            return PartialView("Partial/_PartialGenericRepeatGroupListStyle", repeatGroup);
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


     

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}