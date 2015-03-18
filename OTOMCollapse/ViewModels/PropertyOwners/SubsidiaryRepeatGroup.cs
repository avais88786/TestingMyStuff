using OTOMCollapse.Infrastructure;
using OTOMCollapse.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace OTOMCollapse.ViewModels.RepeatGroups
{
    [Serializable]
    public class SubsidiaryRepeatGroup : RepeatGroupBase,IRepeatGroupContainer
    {
        //private Dictionary<string, Type> propertyTypeMap = new Dictionary<string, Type>() {{ "TestRepeatGroups", typeof(TestRepeatGroup) }};

        public SubsidiaryRepeatGroup()
        {
            NestedRepeatGroup = new List<NestedRepeatGroup>() { new NestedRepeatGroup() };
        }

        //[XmlAttribute("id")]
        //[HiddenInput(DisplayValue = false)]
        //public int Id { get { return base.Id; } set { base.Id = value; } }


        [Required]
        public string CompanyName { get; set; }

        [Required]
        [Range(0,9999999)]
        public string EmployersReferenceNumber { get;set; }

        [XmlElement(typeof(NestedRepeatGroup))]
        [Display(Name = "Nested Repeat Group")]
        [MaximumRepeatGroups(5)]
        public List<NestedRepeatGroup> NestedRepeatGroup { get; set; }

        public RepeatGroupBase GetPropertyType(string propertyName)
        {
            return (RepeatGroupBase)Activator.CreateInstance(this.GetType().GetProperty(propertyName).PropertyType.GetGenericArguments()[0]);
        }


        public string GetTemplateName(string forProperty)
        {
            string templateName = ((UIHintAttribute)this.GetType().GetProperty(forProperty).GetCustomAttributes(typeof(UIHintAttribute), false).FirstOrDefault()).UIHint;

            return templateName;
        }



        public RepeatGroupBase GetPropertyType(Type thisType, string propertyName)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class NestedRepeatGroup : RepeatGroupBase
    {
        public NestedRepeatGroup()
        {

        }

        public int TestInt { get; set; }

        public string TestString { get; set; }
    }
}
