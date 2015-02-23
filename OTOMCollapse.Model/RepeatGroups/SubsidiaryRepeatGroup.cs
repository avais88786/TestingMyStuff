using OTOMCollapse.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.RepeatGroups
{
    public class SubsidiaryRepeatGroup : RepeatGroupBase//,RepeatGroupContainer
    {
        //private Dictionary<string, Type> propertyTypeMap = new Dictionary<string, Type>() {{ "TestRepeatGroups", typeof(TestRepeatGroup) }};

        public SubsidiaryRepeatGroup()
        {
            //TestRepeatGroups = new List<TestRepeatGroup>();
            //for (int i = 0; i < 10; i++)
            //{
            //    TestRepeatGroups.Add(new TestRepeatGroup());
            //}
        }

        public string CompanyName { get; set; }

        public string EmployersReferenceNumber { get;set; }

        //[UIHint("TestRepeatGroup")]
        //[MaximumRepeatGroups(5)]
        //public IList<TestRepeatGroup> TestRepeatGroups { get; set; }

        public IEnumerable<RepeatGroupBase> GetPropertyType(string propertyName)
        {
            //return base.GetPropertyType(propertyTypeMap, propertyName);
            //return (RepeatGroupBase)Activator.CreateInstance(propertyTypeMap[propertyName]);
            return null;
        }


        public string GetTemplateName(string forProperty)
        {
            return null;
        }

        public override IEnumerable<RepeatGroupBase> RepeatGroupProperty
        {
            get { return new List<SubsidiaryRepeatGroup>(){new SubsidiaryRepeatGroup()}.Cast<RepeatGroupBase>(); }
        }
    }
}
