using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OpenGI.MVC.ModelBinders;
using OpenGI.MVC.ViewModels;
using OpenGI.MVC.ViewModels.Tradesman;
using OpenGI.MVC.ViewModels.PropertyOwners;

namespace OpenGI.MVC.Controllers
{
    public class StepFactory
    {
        public static IEnumerable<string> GetSteps(Type thetype)
        {
            return thetype.GetProperties().Select(x => x.PropertyType.FullName);
        }
    }

    public class BusinessLineFactory
    {
        public static IDataCapture GetDataCapture(int id, Type modelType)
        {
            var step = 0;

            List<string> someList;

            switch (id)
            {
                case 1:
                    someList = StepFactory.GetSteps(typeof(PropertyOwnersDataCapture)).ToList();

                    if (modelType != null)
                    {
                        step = someList.IndexOf(modelType.FullName) + 1;
                    }

                    return (IDataCapture)Activator.CreateInstance(Type.GetType(someList[step]));
                case 2:
                    someList = StepFactory.GetSteps(typeof(TradesmanDataCapture)).ToList();

                    if (modelType != null)
                    {
                        step = someList.IndexOf(modelType.FullName) + 1;
                    }

                    return (IDataCapture)Activator.CreateInstance(Type.GetType(someList[step]));
            }

            return null;
        }
    }

    public class BusinessLineController : Controller
    {
        public ActionResult Create()
        {
            var id = 1; // TODO: Get from session

            return View(BusinessLineFactory.GetDataCapture(id, null));
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(DataCaptureModelBinder))]IDataCapture model)
        {
            var id = 1; // TODO: Get from session

            if (!ModelState.IsValid)
            {
                ViewBag.Result = "Sorry, try again";

                return View(model);
            }

            return View(BusinessLineFactory.GetDataCapture(id, model.GetType()));
        }
    }
}