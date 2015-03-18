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

using OTOMCollapse.ViewModels.PropertyOwners;
using OTOMCollapse.ViewModels;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml.Linq;


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


            string xml;            
            PropertyOwnersViewModel vm = new PropertyOwnersViewModel();
            PropertyOwnersViewModelContainer container = new PropertyOwnersViewModelContainer();
            container.PropertyOwnersViewModel = vm;

            var x = this.GetType().GetMethod("DoSomething")
                    .MakeGenericMethod(container.GetType())
                    .Invoke(null, new object[] { container });

            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(PropertyOwnersViewModelContainer));
            XmlSerializer xmlSerializer3 = new XmlSerializer(container.GetType());
            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter xw = XmlWriter.Create(sw))
                {
                    xmlSerializer2.Serialize(xw, container);
                    xml = sw.ToString();
                }
            }

            DataContractSerializerSettings settigns = new DataContractSerializerSettings();

            DataContractSerializer dcs = new DataContractSerializer(container.GetType(), container.GetType().Name,"");
            using (MemoryStream ms = new MemoryStream())
            {
                dcs.WriteObject(ms, container);
                ms.Position = 0;
                var sr = new StreamReader(ms);
                xml = sr.ReadToEnd();
            }

            //@ViewBag.Stream = xml;
            //IEnumerable<string> codeListNames
            //var x = vm.GetCodeListNames();

            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(ms, new XmlWriterSettings() { Indent = true,ConformanceLevel=ConformanceLevel.Auto }))
                {
                    MySerializer<PropertyOwnersViewModelContainer> serialzier = new MySerializer<PropertyOwnersViewModelContainer>(container);
                serialzier.WriteXml(writer);
                writer.Flush();
                ms.Position = 0;
                var sr = new StreamReader(ms);
                xml = sr.ReadToEnd();                        

            }
            }

            //var Xml = XDocument.Parse(xml);
            //foreach (XElement XE in Xml.Root.DescendantsAndSelf())
            //{
            //    // Stripping the namespace by setting the name of the element to it's localname only
            //    XE.Name = XE.Name.LocalName;
            //    // replacing all attributes with attributes that are not namespaces and their names are set to only the localname
            //    XE.ReplaceAttributes((from xattrib in XE.Attributes().Where(xa => !xa.IsNamespaceDeclaration) select new XAttribute(xattrib.Name.LocalName, xattrib.Value)));
            //}

            @ViewBag.Stream = xml;// Xml.ToString();

            Session["test"] = container;
            //Session["test"] = container;
            //TempData.Keep("test");

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
          
            var s = (PropertyOwnersViewModelContainer)Session["test"];
            string xml;
            s.PropertyOwnersViewModel = propertyowners;
            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(PropertyOwnersViewModelContainer));
          
            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter xw = XmlWriter.Create(sw))
                {
                    xmlSerializer2.Serialize(xw, s);
                    xml = sw.ToString();
                }
            }
            
            //PropertyOwnersViewModelContainer vmC;
            //StringReader sr = new StringReader(stringtodeserailzie);
            //using (XmlReader reader = XmlReader.Create(sr))
            //{
            //    vmC = (PropertyOwnersViewModelContainer)xmlSerializer2.Deserialize(reader);
            //}
            //vmC.PropertyOwnersViewModel = propertyowners;
            //vmC.Validate(new System.ComponentModel.DataAnnotations.ValidationContext(vmC));
            


            ModelState.Clear();
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
            ((RepeatGroupBase)repeatGroup).Id = nextIndex;
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

        public static T DoSomething<T>(T value)
        {
            return value;
        }   
    }


    public class MySerializer<T> : IXmlSerializable
    {
        private T myObject;

        public MySerializer(T value)
        {
            myObject = value;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            Dictionary<string, Type> propertyTypeDic = new Dictionary<string, Type>();
            Dictionary<string, PropertyInfo> propertyInfoDic =
                                               new Dictionary<string, PropertyInfo>();

            XmlUtilities.GetTypePropertyDic(myObject.GetType(), ref propertyTypeDic,
                                            ref propertyInfoDic);
            writer.WriteStartElement(myObject.GetType().Name);

            var types = myObject.GetType().GetProperties().Where(p => p.PropertyType.IsInterface);

            foreach (string key in propertyTypeDic.Keys.ToList())
            {
                var types2 = propertyTypeDic[key].GetProperties().Where(p => p.PropertyType.IsInterface);
                var types3 = propertyTypeDic[key].GetNestedTypes();
                XmlSerializer valueSerializer = new XmlSerializer(propertyTypeDic[key],new XmlRootAttribute(key));
                object valueObject = propertyInfoDic[key].GetValue(myObject, null);
                writer.WriteStartElement(null,key,"");
                //Use specific format to serialize datetime
                if (propertyTypeDic[key] == typeof(System.DateTime))
                {
                    valueSerializer = new XmlSerializer(typeof(System.String));
                    DateTime? _tempDt = null;
                    try
                    {
                        _tempDt = Convert.ToDateTime(valueObject);
                    }
                    catch
                    {
                        _tempDt = null;
                    }
                    if (_tempDt != null)
                    {
                        valueSerializer.Serialize(writer,
                                              _tempDt.Value.ToString());
                    }
                }
                else
                {
                    valueSerializer.Serialize(writer, valueObject, null);
                }
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            
        }
    }


    public class XmlUtilities
    {
        public static string SerializeToString(object obj)
        {
            if (obj != null)
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                using (StringWriter writer = new StringWriter())
                {
                    try
                    {
                        serializer.Serialize(writer, obj);

                        return writer.ToString();
                    }
                    catch
                    {
                        return string.Empty;
                    }
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static T SerializeFromString<T>(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StringReader reader = new StringReader(xml))
                {
                    try
                    {
                        return (T)serializer.Deserialize(reader);
                    }
                    catch
                    {
                        throw new Exception("XML document is wrong.");
                    }
                }
            }
            else
            {
                return default(T);
            }
        }

        public static void GetTypePropertyDic(Type type, ref Dictionary<string, Type> propertyTypeDic, ref Dictionary<string, PropertyInfo> propertyInfoDic)
        {
            PropertyInfo[] propertyArray = type.GetProperties(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.SetProperty);
            if (propertyArray != null)
            {
                foreach (PropertyInfo property in propertyArray)
                {
                    propertyTypeDic[property.Name] = property.PropertyType;
                    propertyInfoDic[property.Name] = property;
                }
            }
        }
    }

}