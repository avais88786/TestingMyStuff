using OTOMCollapse.Infrastructure;
using OTOMCollapse.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.RepeatGroups
{
    public class SubsidiaryRepeatGroup : RepeatGroupBase//,IRepeatGroupContainer
    {
        //private Dictionary<string, Type> propertyTypeMap = new Dictionary<string, Type>() {{ "TestRepeatGroups", typeof(TestRepeatGroup) }};

        public SubsidiaryRepeatGroup()
        {
            //NestedRepeatGroup = new List<NestedRepeatGroup>() { new NestedRepeatGroup() };
        }

        public string CompanyName { get; set; }

        public string EmployersReferenceNumber { get;set; }

        //[Display(Name="Nested Repeat Group")]
        //[MaximumRepeatGroups(5)]
        //public IList<NestedRepeatGroup> NestedRepeatGroup { get; set; }

        public RepeatGroupBase GetPropertyType(string propertyName)
        {
            return (RepeatGroupBase)Activator.CreateInstance(this.GetType().GetProperty(propertyName).PropertyType.GetGenericArguments()[0]);
        }


        public string GetTemplateName(string forProperty)
        {
            string templateName = ((UIHintAttribute)this.GetType().GetProperty(forProperty).GetCustomAttributes(typeof(UIHintAttribute), false).FirstOrDefault()).UIHint;

            return templateName;
        }

    }

    public class NestedRepeatGroup : RepeatGroupBase
    {
        public int TestInt { get; set; }

        public string TestString { get; set; }
    }
}
